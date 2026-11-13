using Municipal_Application.DataStructures;
using Municipal_Application.Models;

namespace Municipal_Application.Services
{
    /// <summary>
    /// Organises a set of requests in several data structures at once, each
    /// chosen for the job it does best:
    /// <list type="bullet">
    /// <item>Red-black tree by reference id - looking up one request by its unique identifier.</item>
    /// <item>AVL tree by date submitted - chronological order and date-range searches.</item>
    /// <item>Binary search tree by title - alphabetical order and "starts with" searches.</item>
    /// <item>Max-heap by priority score - ranking the requests that need attention first.</item>
    /// </list>
    /// An index is a snapshot: build a new one whenever the underlying requests change.
    /// </summary>
    public sealed class ServiceRequestIndex
    {
        private readonly DateTime _builtAt;

        private ServiceRequestIndex(DateTime builtAt)
        {
            _builtAt = builtAt;
            ById = new RedBlackTree<int, Issue>();
            ByDate = new AvlTree<(DateTime Date, int Id), Issue>();
            ByTitle = new BinarySearchTree<(string Title, int Id), Issue>(new TitleKeyComparer());
            PriorityHeap = new BinaryHeap<PrioritisedRequest>(new HighestPriorityFirstComparer());
        }

        public RedBlackTree<int, Issue> ById { get; }

        public AvlTree<(DateTime Date, int Id), Issue> ByDate { get; }

        public BinarySearchTree<(string Title, int Id), Issue> ByTitle { get; }

        public BinaryHeap<PrioritisedRequest> PriorityHeap { get; }

        public int Count => ById.Count;

        public int OpenCount => PriorityHeap.Count;

        public static ServiceRequestIndex Build(IEnumerable<Issue> requests, DateTime? now = null)
        {
            var builtAt = now ?? DateTime.Now;
            var index = new ServiceRequestIndex(builtAt);

            foreach (var request in requests)
            {
                index.ById.Insert(request.Id, request);
                index.ByDate.Insert((request.DateReported, request.Id), request);
                index.ByTitle.Insert((request.Title, request.Id), request);

                if (RequestPriorityCalculator.IsOpen(request))
                {
                    index.PriorityHeap.Push(new PrioritisedRequest(request, RequestPriorityCalculator.Score(request, builtAt)));
                }
            }

            return index;
        }

        /// <summary>
        /// Finds a request from text such as "SR-00012", "sr12" or just "12"
        /// using the red-black tree. A prefix that doesn't match the request's
        /// type (e.g. "IR-00012" for a service request) finds nothing.
        /// </summary>
        public Issue? FindByReference(string? text)
        {
            if (!TryParseReference(text, out var id, out var type))
            {
                return null;
            }

            if (!ById.TryGetValue(id, out var issue))
            {
                return null;
            }

            return type == null || type == issue.RequestType ? issue : null;
        }

        public static bool TryParseReference(string? text, out int id, out RequestType? type)
        {
            id = 0;
            type = null;

            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            var cleaned = text.Trim().Replace(" ", string.Empty).TrimStart('#');
            var prefixLength = cleaned.TakeWhile(char.IsLetter).Count();
            var prefix = cleaned[..prefixLength].ToUpperInvariant();
            var number = cleaned[prefixLength..].TrimStart('-');

            switch (prefix)
            {
                case "":
                    break;
                case "SR":
                    type = RequestType.ServiceRequest;
                    break;
                case "IR":
                    type = RequestType.IssueReport;
                    break;
                default:
                    return false;
            }

            return number.Length > 0 && number.All(char.IsDigit) && int.TryParse(number, out id);
        }

        public IEnumerable<Issue> InReferenceOrder() => ById.InOrder().Select(pair => pair.Value);

        public IEnumerable<Issue> OldestFirst() => ByDate.InOrder().Select(pair => pair.Value);

        public IEnumerable<Issue> NewestFirst() => OldestFirst().Reverse();

        public IEnumerable<Issue> InTitleOrder() => ByTitle.InOrder().Select(pair => pair.Value);

        /// <summary>Requests whose title starts with the text, found with a range query on the binary search tree.</summary>
        public IEnumerable<Issue> SearchByTitlePrefix(string prefix)
        {
            return ByTitle.Range((prefix, int.MinValue), (prefix + '￿', int.MaxValue))
                .Select(pair => pair.Value);
        }

        /// <summary>Requests submitted between two dates (either end may be open), found with a range query on the AVL tree.</summary>
        public IEnumerable<Issue> SearchByDateRange(DateTime? from, DateTime? to)
        {
            var low = from?.Date ?? DateTime.MinValue;
            var high = to?.Date.AddDays(1).AddTicks(-1) ?? DateTime.MaxValue;
            return ByDate.Range((low, int.MinValue), (high, int.MaxValue)).Select(pair => pair.Value);
        }

        /// <summary>The requests that most need attention, highest priority first, from the heap.</summary>
        public IReadOnlyList<PrioritisedRequest> TopPriorities(int count) => PriorityHeap.PeekTop(count);

        /// <summary>
        /// Every request ranked by priority (a heap sort of the open requests),
        /// followed by the resolved and closed ones, newest first.
        /// </summary>
        public IEnumerable<Issue> InPriorityOrder()
        {
            var open = PriorityHeap.ToSortedList().Select(ranked => ranked.Issue);
            var finished = NewestFirst().Where(request => !RequestPriorityCalculator.IsOpen(request));
            return open.Concat(finished);
        }

        public int ScoreOf(Issue issue) => RequestPriorityCalculator.Score(issue, _builtAt);

        private sealed class TitleKeyComparer : IComparer<(string Title, int Id)>
        {
            public int Compare((string Title, int Id) x, (string Title, int Id) y)
            {
                var byTitle = StringComparer.OrdinalIgnoreCase.Compare(x.Title, y.Title);
                return byTitle != 0 ? byTitle : x.Id.CompareTo(y.Id);
            }
        }

        /// <summary>Highest score first; ties go to the request that has waited longest.</summary>
        private sealed class HighestPriorityFirstComparer : IComparer<PrioritisedRequest>
        {
            public int Compare(PrioritisedRequest? x, PrioritisedRequest? y)
            {
                var byScore = y!.Score.CompareTo(x!.Score);
                if (byScore != 0) return byScore;
                var byAge = x.Issue.DateReported.CompareTo(y.Issue.DateReported);
                return byAge != 0 ? byAge : x.Issue.Id.CompareTo(y.Issue.Id);
            }
        }
    }
}
