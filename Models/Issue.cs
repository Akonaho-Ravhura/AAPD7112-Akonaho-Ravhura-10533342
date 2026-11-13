namespace Municipal_Application.Models
{
    public class Issue
    {
        public int Id { get; set; }

        /// <summary>
        /// The unique, resident-friendly identifier used to track a request,
        /// e.g. "SR-00012" for a service request or "IR-00007" for an issue report.
        /// </summary>
        public string ReferenceNumber =>
            $"{(RequestType == RequestType.ServiceRequest ? "SR" : "IR")}-{Id:D5}";

        public RequestType RequestType { get; set; } = RequestType.IssueReport;

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        
        /// The category (for an issue report, e.g. "Water") or service type
        /// (for a service request, e.g. "BinCollection") as free text, so
        /// both request types can share this single field.
       
        public string Category { get; set; } = string.Empty;

        public IssueStatus Status { get; set; } = IssueStatus.Submitted;

        public DateTime DateReported { get; set; } = DateTime.Now;

        public string ReportedByUsername { get; set; } = string.Empty;

        public List<string> AttachmentPaths { get; set; } = new();
    }
}
