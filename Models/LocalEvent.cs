namespace Municipal_Application.Models
{
    
    /// A local event, notice, or announcement posted by a municipal admin
    /// for residents to see.
    public class LocalEvent
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public LocalEventCategory Category { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime EventDate { get; set; } = DateTime.Today;

        public DateTime PostedDate { get; set; } = DateTime.Now;

        public string PostedByUsername { get; set; } = string.Empty;
    }
}
