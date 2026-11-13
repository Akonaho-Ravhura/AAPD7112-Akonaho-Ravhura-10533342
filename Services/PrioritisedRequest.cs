using Municipal_Application.Models;

namespace Municipal_Application.Services
{
    /// <summary>A request together with the priority score the heap ranked it by.</summary>
    public sealed record PrioritisedRequest(Issue Issue, int Score);
}
