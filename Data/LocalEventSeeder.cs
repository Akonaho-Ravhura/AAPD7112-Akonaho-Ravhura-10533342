using Municipal_Application.Models;

namespace Municipal_Application.Data
{
    /// <summary>
    /// Adds a maximum of twenty realistic sample events while the application is open.
    /// The first event is posted at startup; remaining events arrive every 2.5 minutes.
    /// </summary>
    public sealed class LocalEventSeeder
    {
        private static readonly LocalEventSeeder _instance = new();
        public static LocalEventSeeder Instance => _instance;

        private static readonly string[] _locations =
        {
            "Civic Centre", "Riverside Community Hall", "Central Library", "Ward 4 Sports Ground",
            "Market Street", "Northside Clinic", "Greenfields Park", "Harbour Road"
        };

        private readonly object _sync = new();
        private System.Threading.Timer? _timer;
        private int _seededCount;

        private LocalEventSeeder() { }

        public void Start()
        {
            lock (_sync)
            {
                if (_timer != null || _seededCount >= 20) return;
                _timer = new System.Threading.Timer(SeedOneEvent, null, TimeSpan.Zero, TimeSpan.FromMinutes(2.5));
            }
        }

        private void SeedOneEvent(object? state)
        {
            lock (_sync)
            {
                if (_seededCount >= 20)
                {
                    _timer?.Change(Timeout.Infinite, Timeout.Infinite);
                    return;
                }

                LocalEventRepository.Instance.Add(CreateRandomEvent());
                _seededCount++;
                if (_seededCount >= 20)
                {
                    _timer?.Change(Timeout.Infinite, Timeout.Infinite);
                }
            }
        }

        private static LocalEvent CreateRandomEvent()
        {
            var category = (LocalEventCategory)Random.Shared.Next(Enum.GetValues<LocalEventCategory>().Length);
            var location = _locations[Random.Shared.Next(_locations.Length)];
            var eventDate = DateTime.Today.AddDays(Random.Shared.Next(1, 61))
                .AddHours(new[] { 8, 10, 14, 17 }[Random.Shared.Next(4)]);

            var (title, description) = category switch
            {
                LocalEventCategory.ServiceInterruption => (
                    new[] { "Planned water interruption", "Electricity maintenance notice", "Temporary service interruption" }[Random.Shared.Next(3)],
                    $"Municipal teams will be working near {location}. Residents are encouraged to store essential water and plan for a short service interruption. Updates will be shared if the schedule changes."),
                LocalEventCategory.MaintenanceActivity => (
                    new[] { "Road resurfacing works", "Community park maintenance", "Waste collection schedule update" }[Random.Shared.Next(3)],
                    $"A municipal maintenance team is scheduled to work near {location}. Please follow temporary signs and allow extra time when travelling through the area."),
                LocalEventCategory.CommunityNotice => (
                    new[] { "Community clean-up day", "Neighbourhood safety meeting", "Community gardening morning" }[Random.Shared.Next(3)],
                    $"Residents are invited to take part at {location}. Municipal staff and local volunteers will be available to share information and help with the activity."),
                LocalEventCategory.PublicAnnouncement => (
                    new[] { "Municipal services information session", "Public participation meeting", "Resident support desk" }[Random.Shared.Next(3)],
                    $"Join municipal representatives at {location} for service information and assistance. Bring any relevant reference numbers or supporting documents."),
                LocalEventCategory.ProgressUpdate => (
                    new[] { "Infrastructure project progress update", "Water network upgrade update", "Road repair progress report" }[Random.Shared.Next(3)],
                    $"Work in the {location} area is progressing. The municipality will provide another update after the next project milestone and appreciates residents' patience."),
                _ => (
                    new[] { "Local community information day", "Municipal notice", "Community services update" }[Random.Shared.Next(3)],
                    $"Please visit {location} for the latest information from your municipality. Contact the municipal office if you need help or accessibility support.")
            };

            return new LocalEvent
            {
                Title = title,
                Category = category,
                Description = description,
                EventDate = eventDate,
                PostedDate = DateTime.Now,
                PostedByUsername = "Municipal Community Desk"
            };
        }
    }
}
