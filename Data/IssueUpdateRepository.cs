using Municipal_Application.Models;

namespace Municipal_Application.Data
{
    
    /// In-memory store for the update timeline (status changes, comments and
    /// photos) posted against reported issues and service requests.
    
    public class IssueUpdateRepository
    {
        private static readonly IssueUpdateRepository _instance = new();

        public static IssueUpdateRepository Instance => _instance;

        private readonly List<IssueUpdate> _updates = new();
        private int _nextId = 1;

        private IssueUpdateRepository()
        {
        }

        public IssueUpdate Add(IssueUpdate update)
        {
            update.Id = _nextId++;
            _updates.Add(update);
            return update;
        }

        public List<IssueUpdate> GetByIssueId(int issueId)
        {
            return _updates
                .Where(u => u.IssueId == issueId)
                .OrderBy(u => u.PostedDate)
                .ToList();
        }
    }
}
