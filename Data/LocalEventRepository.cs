using Municipal_Application.Models;

namespace Municipal_Application.Data
{
    
    /// In-memory store for local events, notices and announcements posted by admins.
    
    public class LocalEventRepository
    {
        private static readonly LocalEventRepository _instance = new();

        public static LocalEventRepository Instance => _instance;

        private readonly List<LocalEvent> _events = new();
        private int _nextId = 1;

        private LocalEventRepository()
        {
        }

        public LocalEvent Add(LocalEvent localEvent)
        {
            localEvent.Id = _nextId++;
            _events.Add(localEvent);
            return localEvent;
        }

        public List<LocalEvent> GetAll()
        {
            return _events.OrderByDescending(e => e.PostedDate).ToList();
        }
    }
}
