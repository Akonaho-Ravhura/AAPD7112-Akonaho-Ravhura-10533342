using Municipal_Application.Models;

namespace Municipal_Application.Data
{
    /// <summary>
    /// Adds a small set of sample community requests when the application
    /// starts, so the Service Request Status page has realistic data to
    /// organise (the data is held in memory only and disappears on exit).
    /// A few requests belong to the documented test resident, ID 9001015001083.
    /// </summary>
    public static class ServiceRequestSeeder
    {
        public const string DemoResidentId = "9001015001083";

        private const string NeighbourA = "8203125800081";
        private const string NeighbourB = "9507206100086";
        private const string NeighbourC = "7811045900083";
        private const string NeighbourD = "8811135200081";
        private const string NeighbourE = "9211250300088";

        public static void SeedIfEmpty()
        {
            if (IssueRepository.Instance.Count > 0)
            {
                return;
            }

            var now = DateTime.Now;

            // Requests belonging to the demo resident.
            var missedCollection = Add(RequestType.ServiceRequest, "BinCollection", "Missed refuse collection", "Oak Avenue",
                "Our bin was not collected on the last two scheduled days.", IssueStatus.InProgress, now.AddDays(-9), DemoResidentId);
            Add(RequestType.ServiceRequest, "NewWaterConnection", "New water connection for extension", "Oak Avenue",
                "We have built a granny flat and need a separate water connection.", IssueStatus.Submitted, now.AddDays(-4), DemoResidentId);
            var burstPipe = Add(RequestType.IssueReport, "Water", "Burst pipe outside house", "Oak Avenue",
                "Water has been running down the road since this morning.", IssueStatus.Resolved, now.AddDays(-21), DemoResidentId);
            Add(RequestType.ServiceRequest, "IndigentSupportApplication", "Indigent support registration", "Ward 4 Clinic Road",
                "Applying to register our household for indigent support.", IssueStatus.Submitted, now.AddDays(-14), DemoResidentId);

            // Other residents' requests, which relate to the ones above by place or category.
            var pothole = Add(RequestType.IssueReport, "Roads", "Large pothole", "Main Street",
                "A deep pothole near the taxi rank is damaging vehicles.", IssueStatus.InProgress, now.AddDays(-12), NeighbourA);
            Add(RequestType.IssueReport, "Roads", "Faded road markings", "Main Street",
                "Pedestrian crossing markings are no longer visible.", IssueStatus.Submitted, now.AddDays(-6), NeighbourB);
            Add(RequestType.ServiceRequest, "BinCollection", "Extra bins for community event", "Main Street",
                "Requesting additional bins for the weekend market.", IssueStatus.Resolved, now.AddDays(-18), NeighbourC);
            Add(RequestType.IssueReport, "Electricity", "Streetlight not working", "Main Street",
                "The streetlight outside the pharmacy has been off for a week.", IssueStatus.Submitted, now.AddDays(-3), NeighbourA);
            Add(RequestType.IssueReport, "Water", "Low water pressure", "Riverside Park",
                "Very low pressure every evening.", IssueStatus.InProgress, now.AddDays(-10), NeighbourD);
            Add(RequestType.ServiceRequest, "NewWaterConnection", "Water connection quote", "Riverside Park",
                "Requesting a quote for a new stand connection.", IssueStatus.Closed, now.AddDays(-28), NeighbourE);
            Add(RequestType.IssueReport, "Sanitation", "Blocked storm drain", "Riverside Park",
                "The drain floods the pavement when it rains.", IssueStatus.Submitted, now.AddDays(-2), NeighbourC);
            Add(RequestType.ServiceRequest, "BinCollection", "Replacement wheelie bin", "Market Square",
                "Our bin was damaged during collection.", IssueStatus.Submitted, now.AddDays(-5), NeighbourD);
            Add(RequestType.IssueReport, "WasteManagement", "Illegal dumping", "Market Square",
                "Builders rubble has been dumped behind the stalls.", IssueStatus.InProgress, now.AddDays(-15), NeighbourB);
            Add(RequestType.ServiceRequest, "RatesAndTaxesQuery", "Rates account query", "Market Square",
                "Query about the valuation on our rates account.", IssueStatus.Resolved, now.AddDays(-20), NeighbourE);
            Add(RequestType.IssueReport, "Electricity", "Exposed wires on pole", "Oak Avenue",
                "Live wires hanging low next to the school gate.", IssueStatus.InProgress, now.AddDays(-7), NeighbourA);
            Add(RequestType.ServiceRequest, "EventOrFacilityBooking", "Book the community hall", "Ward 4 Clinic Road",
                "Booking the hall for a health awareness day.", IssueStatus.Closed, now.AddDays(-25), NeighbourC);

            AddUpdate(missedCollection, IssueStatus.InProgress, "Collection crew has been notified. Your bin will be collected within 48 hours.", 1);
            AddUpdate(burstPipe, IssueStatus.InProgress, "Plumbing team dispatched to Oak Avenue.", 1);
            AddUpdate(burstPipe, IssueStatus.Resolved, "Pipe repaired and water supply restored.", 3);
            AddUpdate(pothole, IssueStatus.InProgress, "Roads department has scheduled a repair crew.", 2);
        }

        private static Issue Add(RequestType type, string category, string title, string location,
            string description, IssueStatus status, DateTime reportedOn, string residentId)
        {
            return IssueRepository.Instance.Add(new Issue
            {
                RequestType = type,
                Category = category,
                Title = title,
                Location = location,
                Description = description,
                Status = status,
                DateReported = reportedOn,
                ReportedByUsername = residentId
            });
        }

        private static void AddUpdate(Issue issue, IssueStatus status, string comment, int daysAfterReported)
        {
            IssueUpdateRepository.Instance.Add(new IssueUpdate
            {
                IssueId = issue.Id,
                Status = status,
                Comment = comment,
                PostedDate = issue.DateReported.AddDays(daysAfterReported),
                PostedByUsername = "admin"
            });
        }
    }
}
