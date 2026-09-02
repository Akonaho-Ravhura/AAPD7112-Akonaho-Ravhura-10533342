using Municipal_Application.Models;

namespace Municipal_Application.Data
{
    
    /// In-memory store for reported issues. Swap the backing storage here
    /// once the required data structure / persistence mechanism is decided.
        public class IssueRepository
    {
        private static readonly IssueRepository _instance = new();

        public static IssueRepository Instance => _instance;

        private readonly List<Issue> _issues = new();
        private int _nextId = 1;

        private IssueRepository()
        {
        }

        public Issue Add(Issue issue)
        {
            issue.Id = _nextId++;
            _issues.Add(issue);
            return issue;
        }

        public List<Issue> GetAll()
        {
            return _issues.ToList();
        }

        public List<Issue> GetByResident(string username)
        {
            return _issues.Where(i => i.ReportedByUsername == username).ToList();
        }

        public Issue? GetById(int id)
        {
            return _issues.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateStatus(int id, IssueStatus newStatus)
        {
            var issue = GetById(id);
            if (issue != null)
            {
                issue.Status = newStatus;
            }
        }

        public int Count => _issues.Count;
    }
}
