using Municipal_Application.DataStructures;
using Municipal_Application.Models;

namespace Municipal_Application.Services
{
    /// <summary>
    /// Models how reported issues and service requests relate to each other as
    /// a weighted graph. Each request is a node. Two requests are connected when
    /// they share a location and/or a category; the lower the edge weight, the
    /// more closely related they are:
    /// <list type="bullet">
    /// <item>1 - same location and same category</item>
    /// <item>2 - same location</item>
    /// <item>3 - same category</item>
    /// </list>
    /// Traversing the graph finds clusters of related requests (for example,
    /// several faults on one street), and a minimum spanning tree shows the
    /// most closely related chain that links the whole cluster together.
    /// </summary>
    public sealed class RequestRelationshipGraph
    {
        public const int SameLocationAndCategory = 1;
        public const int SameLocation = 2;
        public const int SameCategory = 3;

        private RequestRelationshipGraph(WeightedGraph graph)
        {
            Graph = graph;
        }

        public WeightedGraph Graph { get; }

        public static RequestRelationshipGraph Build(IEnumerable<Issue> requests)
        {
            var all = requests.ToList();
            var graph = new WeightedGraph();
            foreach (var request in all)
            {
                graph.AddNode(request.Id);
            }

            // Only compare requests that share a location or a category,
            // instead of every possible pair.
            var candidatePairs = new HashSet<(int, int)>();
            AddPairsWithinGroups(all.GroupBy(r => Normalise(r.Location)), candidatePairs);
            AddPairsWithinGroups(all.GroupBy(r => Normalise(r.Category)), candidatePairs);

            var byId = all.ToDictionary(r => r.Id);
            foreach (var (first, second) in candidatePairs)
            {
                var weight = CalculateWeight(byId[first], byId[second]);
                if (weight > 0)
                {
                    graph.AddEdge(first, second, weight);
                }
            }

            return new RequestRelationshipGraph(graph);
        }

        /// <summary>Returns 0 when the two requests are unrelated.</summary>
        public static int CalculateWeight(Issue first, Issue second)
        {
            var sameLocation = HasValue(first.Location) && Normalise(first.Location) == Normalise(second.Location);
            var sameCategory = HasValue(first.Category) && Normalise(first.Category) == Normalise(second.Category);

            if (sameLocation && sameCategory) return SameLocationAndCategory;
            if (sameLocation) return SameLocation;
            if (sameCategory) return SameCategory;
            return 0;
        }

        public static string DescribeWeight(int weight)
        {
            return weight switch
            {
                SameLocationAndCategory => "location + category",
                SameLocation => "same location",
                SameCategory => "same category",
                _ => "related"
            };
        }

        private static void AddPairsWithinGroups(IEnumerable<IGrouping<string, Issue>> groups, HashSet<(int, int)> pairs)
        {
            foreach (var group in groups)
            {
                if (group.Key.Length == 0)
                {
                    continue;
                }

                var members = group.Select(r => r.Id).OrderBy(id => id).ToList();
                for (var i = 0; i < members.Count; i++)
                {
                    for (var j = i + 1; j < members.Count; j++)
                    {
                        pairs.Add((members[i], members[j]));
                    }
                }
            }
        }

        private static bool HasValue(string text) => !string.IsNullOrWhiteSpace(text);

        private static string Normalise(string text) => text.Trim().ToLowerInvariant();
    }
}
