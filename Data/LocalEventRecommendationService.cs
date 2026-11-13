using Municipal_Application.Models;

namespace Municipal_Application.Data
{
    /// <summary>
    /// Tracks each resident's recent searches and uses category and keyword
    /// frequency to suggest upcoming events from matching interests.
    /// </summary>
    public sealed class LocalEventRecommendationService
    {
        private static readonly LocalEventRecommendationService _instance = new();
        public static LocalEventRecommendationService Instance => _instance;

        private readonly object _sync = new();
        private readonly Dictionary<string, SearchProfile> _profiles = new(StringComparer.OrdinalIgnoreCase);

        private LocalEventRecommendationService() { }

        public void RecordSearch(string username, string query, LocalEventCategory? category,
            DateTime from, DateTime to)
        {
            lock (_sync)
            {
                if (!_profiles.TryGetValue(username, out var profile))
                {
                    profile = new SearchProfile();
                    _profiles.Add(username, profile);
                }

                profile.History.Push(new SearchPattern(query, category, from.Date, to.Date, DateTime.Now));
                if (category.HasValue)
                {
                    profile.CategoryCounts[category.Value] = profile.CategoryCounts.GetValueOrDefault(category.Value) + 1;
                }

                foreach (var word in GetKeywords(query))
                {
                    profile.KeywordCounts[word] = profile.KeywordCounts.GetValueOrDefault(word) + 1;
                }

                profile.SearchedDates.Add(DateOnly.FromDateTime(from));
                profile.SearchedDates.Add(DateOnly.FromDateTime(to));
            }
        }

        public List<LocalEvent> GetRecommendations(string username, IEnumerable<LocalEvent> currentResults, int count = 3)
        {
            var excludedIds = currentResults.Select(localEvent => localEvent.Id).ToHashSet();
            Dictionary<LocalEventCategory, int> categories;
            Dictionary<string, int> keywords;
            HashSet<DateOnly> searchedDates;
            SearchPattern? mostRecentSearch;

            lock (_sync)
            {
                if (!_profiles.TryGetValue(username, out var profile))
                {
                    return LocalEventRepository.Instance.GetNearestUpcoming(count);
                }

                categories = new Dictionary<LocalEventCategory, int>(profile.CategoryCounts);
                keywords = new Dictionary<string, int>(profile.KeywordCounts, StringComparer.OrdinalIgnoreCase);
                searchedDates = new HashSet<DateOnly>(profile.SearchedDates);
                profile.History.TryPeek(out mostRecentSearch);
            }

            var events = LocalEventRepository.Instance.GetAll()
                .Where(localEvent => localEvent.EventDate.Date >= DateTime.Today)
                .Where(localEvent => !excludedIds.Contains(localEvent.Id))
                .ToList();

            var categoryPreferences = categories
                .OrderByDescending(item => item.Value)
                .ThenByDescending(item => mostRecentSearch?.Category == item.Key)
                .Select(item => item.Key).ToList();
            if (categoryPreferences.Count > 0)
            {
                var preferred = events.Where(localEvent => localEvent.Category == categoryPreferences[0])
                    .OrderBy(localEvent => DateDistanceFromSearch(localEvent, searchedDates))
                    .ThenBy(localEvent => localEvent.EventDate).Take(count).ToList();
                if (preferred.Count > 0) return preferred;
            }

            if (keywords.Count > 0)
            {
                var keywordRecommendations = events
                    .Select(localEvent => new
                    {
                        Event = localEvent,
                        Score = keywords.Sum(item => item.Value *
                            ((localEvent.Title.Contains(item.Key, StringComparison.CurrentCultureIgnoreCase) ? 2 : 0) +
                             (localEvent.Description.Contains(item.Key, StringComparison.CurrentCultureIgnoreCase) ? 1 : 0)))
                    })
                    .Where(item => item.Score > 0)
                    .OrderByDescending(item => item.Score)
                    .ThenBy(item => item.Event.EventDate)
                    .Take(count)
                    .Select(item => item.Event)
                    .ToList();
                if (keywordRecommendations.Count > 0) return keywordRecommendations;
            }

            var fallback = events.OrderBy(localEvent => localEvent.EventDate).Take(count).ToList();
            return fallback.Count > 0 ? fallback : LocalEventRepository.Instance.GetNearestUpcoming(count);
        }

        private static IEnumerable<string> GetKeywords(string query)
        {
            return query.Split(new[] { ' ', ',', '.', ';', ':', '-', '_' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(word => word.Length >= 3)
                .Select(word => word.ToLowerInvariant());
        }

        private static int DateDistanceFromSearch(LocalEvent localEvent, HashSet<DateOnly> searchedDates)
        {
            if (searchedDates.Count == 0) return 0;
            var eventDate = DateOnly.FromDateTime(localEvent.EventDate);
            return searchedDates.Min(date => Math.Abs(date.DayNumber - eventDate.DayNumber));
        }

        private sealed class SearchProfile
        {
            public Stack<SearchPattern> History { get; } = new();
            public Dictionary<LocalEventCategory, int> CategoryCounts { get; } = new();
            public Dictionary<string, int> KeywordCounts { get; } = new(StringComparer.OrdinalIgnoreCase);
            public HashSet<DateOnly> SearchedDates { get; } = new();
        }

        private sealed record SearchPattern(string Query, LocalEventCategory? Category,
            DateTime From, DateTime To, DateTime SearchedAt);
    }
}
