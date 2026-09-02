namespace Municipal_Application.Models
{
    
    /// A single status change posted by an admin against an issue or service
    /// request, optionally including a comment and photos.
    
    public class IssueUpdate
    {
        public int Id { get; set; }

        public int IssueId { get; set; }

        public IssueStatus Status { get; set; }

        public string Comment { get; set; } = string.Empty;

        public List<string> AttachmentPaths { get; set; } = new();

        public DateTime PostedDate { get; set; } = DateTime.Now;

        public string PostedByUsername { get; set; } = string.Empty;
    }
}
