using Municipal_Application.Models;

namespace Municipal_Application.Data
{
    
    /// Thread-safe in-memory event store with indexes for date and category searches.
    
    public class LocalEventRepository
    {
        private static readonly LocalEventRepository _instance = new();

        public static LocalEventRepository Instance => _instance;

        private readonly object _sync = new();
        private readonly Dictionary<int, LocalEvent> _eventsById = new();
        private readonly SortedDictionary<DateTime, List<LocalEvent>> _eventsByDate = new();
        private readonly Dictionary<LocalEventCategory, HashSet<int>> _eventIdsByCategory = new();
        private readonly HashSet<LocalEventCategory> _categories = new();
        private readonly HashSet<DateOnly> _eventDates = new();
        private readonly PriorityQueue<LocalEvent, DateTime> _upcomingEvents = new();
        private int _nextId = 1;

        private LocalEventRepository()
        {
        }

        public LocalEvent Add(LocalEvent localEvent)
        {
            lock (_sync)
            {
                localEvent.Id = _nextId++;
                var eventDate = localEvent.EventDate.Date;

                _eventsById.Add(localEvent.Id, localEvent);
                if (!_eventsByDate.TryGetValue(eventDate, out var dateEvents))
                {
                    dateEvents = new List<LocalEvent>();
                    _eventsByDate.Add(eventDate, dateEvents);
                }
                dateEvents.Add(localEvent);

                if (!_eventIdsByCategory.TryGetValue(localEvent.Category, out var categoryIds))
                {
                    categoryIds = new HashSet<int>();
                    _eventIdsByCategory.Add(localEvent.Category, categoryIds);
                }
                categoryIds.Add(localEvent.Id);
                _categories.Add(localEvent.Category);
                _eventDates.Add(DateOnly.FromDateTime(eventDate));
                _upcomingEvents.Enqueue(localEvent, eventDate);
                return localEvent;
            }
        }

        public List<LocalEvent> GetAll()
        {
            lock (_sync)
            {
                return _eventsByDate.Values.SelectMany(events => events)
                    .OrderBy(e => e.EventDate).ThenByDescending(e => e.PostedDate).ToList();
            }
        }

        public List<LocalEvent> Search(string query, LocalEventCategory? category, DateTime from, DateTime to)
        {
            lock (_sync)
            {
                if (to.Date < from.Date)
                {
                    return new List<LocalEvent>();
                }

                IEnumerable<LocalEvent> candidates;
                if (category.HasValue && _eventIdsByCategory.TryGetValue(category.Value, out var categoryIds))
                {
                    candidates = categoryIds.Select(id => _eventsById[id]);
                }
                else if (category.HasValue)
                {
                    return new List<LocalEvent>();
                }
                else
                {
                    candidates = _eventsByDate
                        .Where(entry => entry.Key >= from.Date && entry.Key <= to.Date)
                        .SelectMany(entry => entry.Value);
                }

                return candidates
                    .Where(e => e.EventDate.Date >= from.Date && e.EventDate.Date <= to.Date)
                    .Where(e => string.IsNullOrWhiteSpace(query) ||
                        e.Title.Contains(query.Trim(), StringComparison.CurrentCultureIgnoreCase) ||
                        e.Description.Contains(query.Trim(), StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(e => e.EventDate)
                    .ThenBy(e => e.Title)
                    .ToList();
            }
        }

        public List<LocalEventCategory> GetCategories()
        {
            lock (_sync)
            {
                return _categories.OrderBy(category => category.ToString()).ToList();
            }
        }

        public HashSet<DateOnly> GetUniqueEventDates()
        {
            lock (_sync)
            {
                return new HashSet<DateOnly>(_eventDates);
            }
        }

        public List<LocalEvent> GetNearestUpcoming(int count, DateTime? from = null)
        {
            lock (_sync)
            {
                var minimumDate = (from ?? DateTime.Today).Date;
                var queue = new PriorityQueue<LocalEvent, DateTime>();
                foreach (var item in _upcomingEvents.UnorderedItems)
                {
                    queue.Enqueue(item.Element, item.Priority);
                }

                var results = new List<LocalEvent>();
                while (queue.Count > 0 && results.Count < count)
                {
                    var localEvent = queue.Dequeue();
                    if (localEvent.EventDate.Date >= minimumDate)
                    {
                        results.Add(localEvent);
                    }
                }

                return results;
            }
        }
    }
}
