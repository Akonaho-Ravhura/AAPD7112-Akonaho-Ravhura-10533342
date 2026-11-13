using Municipal_Application.Models;

namespace Municipal_Application.Services
{
    /// <summary>
    /// Scores how urgently an open request needs attention. The score rises with
    /// the importance of the service, with every day the request has been open,
    /// and while nobody has responded yet. Resolved and closed requests score 0.
    /// </summary>
    public static class RequestPriorityCalculator
    {
        private const int CategoryPoints = 10;
        private const int PointsPerDayOpen = 2;
        private const int AwaitingResponseBonus = 15;

        public static bool IsOpen(Issue issue) =>
            issue.Status is IssueStatus.Submitted or IssueStatus.InProgress;

        public static int Score(Issue issue, DateTime now)
        {
            if (!IsOpen(issue))
            {
                return 0;
            }

            var daysOpen = Math.Max(0, (int)(now - issue.DateReported).TotalDays);
            var awaitingResponse = issue.Status == IssueStatus.Submitted ? AwaitingResponseBonus : 0;

            return CategoryWeight(issue.Category) * CategoryPoints
                + daysOpen * PointsPerDayOpen
                + awaitingResponse;
        }

        /// <summary>Basic services (water, power, sanitation) outrank routine queries.</summary>
        private static int CategoryWeight(string category)
        {
            return category.ToLowerInvariant() switch
            {
                "electricity" or "water" => 5,
                "sanitation" or "indigentsupportapplication" => 4,
                "roads" or "wastemanagement" or "newwaterconnection" or "newelectricityconnection" => 3,
                "bincollection" => 2,
                _ => 1
            };
        }
    }
}
