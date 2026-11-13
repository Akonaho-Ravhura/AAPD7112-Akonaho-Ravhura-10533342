namespace Municipal_Application.DataStructures
{
    /// <summary>
    /// One node reached during a traversal: which node it is, the node it was
    /// reached from (null for the starting node), how many steps from the
    /// start, and the weight of the edge that was used to reach it.
    /// </summary>
    public sealed record TraversalStep(int Node, int? Parent, int Depth, int EdgeWeight);

    public sealed record SpanningTree(IReadOnlyList<TraversalStep> Steps, int TotalWeight);

    /// <summary>
    /// An undirected, weighted graph stored as adjacency lists. Nodes are
    /// integer ids. Neighbours are always visited in ascending id order so
    /// every traversal gives the same, repeatable result.
    /// </summary>
    public class WeightedGraph
    {
        private readonly Dictionary<int, SortedDictionary<int, int>> _adjacency = new();

        public int NodeCount => _adjacency.Count;

        public int EdgeCount => _adjacency.Values.Sum(neighbours => neighbours.Count) / 2;

        public bool Contains(int node) => _adjacency.ContainsKey(node);

        public void AddNode(int node)
        {
            if (!_adjacency.ContainsKey(node))
            {
                _adjacency[node] = new SortedDictionary<int, int>();
            }
        }

        /// <summary>
        /// Connects two nodes (adding them if needed). If they are already
        /// connected, the lighter of the two weights is kept.
        /// </summary>
        public void AddEdge(int first, int second, int weight)
        {
            if (first == second)
            {
                return;
            }

            AddNode(first);
            AddNode(second);

            if (_adjacency[first].TryGetValue(second, out var existing) && existing <= weight)
            {
                return;
            }

            _adjacency[first][second] = weight;
            _adjacency[second][first] = weight;
        }

        public IReadOnlyList<(int Node, int Weight)> GetNeighbours(int node)
        {
            return _adjacency.TryGetValue(node, out var neighbours)
                ? neighbours.Select(pair => (pair.Key, pair.Value)).ToList()
                : new List<(int, int)>();
        }

        /// <summary>
        /// Visits the start node, then everything one edge away, then everything
        /// two edges away, and so on, using a queue. Finds the fewest-hops route.
        /// </summary>
        public IReadOnlyList<TraversalStep> BreadthFirst(int start)
        {
            var result = new List<TraversalStep>();
            if (!Contains(start))
            {
                return result;
            }

            var visited = new HashSet<int> { start };
            var queue = new Queue<TraversalStep>();
            queue.Enqueue(new TraversalStep(start, null, 0, 0));

            while (queue.Count > 0)
            {
                var step = queue.Dequeue();
                result.Add(step);

                foreach (var (neighbour, weight) in _adjacency[step.Node])
                {
                    if (visited.Add(neighbour))
                    {
                        queue.Enqueue(new TraversalStep(neighbour, step.Node, step.Depth + 1, weight));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Follows one chain of connections as deep as it goes before backing up
        /// to try the next branch, using a stack.
        /// </summary>
        public IReadOnlyList<TraversalStep> DepthFirst(int start)
        {
            var result = new List<TraversalStep>();
            if (!Contains(start))
            {
                return result;
            }

            var visited = new HashSet<int>();
            var stack = new Stack<TraversalStep>();
            stack.Push(new TraversalStep(start, null, 0, 0));

            while (stack.Count > 0)
            {
                var step = stack.Pop();
                if (!visited.Add(step.Node))
                {
                    continue;
                }

                result.Add(step);

                // Push in reverse so the smallest neighbour id is visited first.
                foreach (var (neighbour, weight) in _adjacency[step.Node].Reverse())
                {
                    if (!visited.Contains(neighbour))
                    {
                        stack.Push(new TraversalStep(neighbour, step.Node, step.Depth + 1, weight));
                    }
                }
            }

            return result;
        }

        /// <summary>Every node reachable from <paramref name="start"/>, including itself.</summary>
        public IReadOnlyList<int> GetConnectedComponent(int start)
        {
            return BreadthFirst(start).Select(step => step.Node).ToList();
        }

        /// <summary>
        /// Prim's algorithm: grows a tree from the start node by repeatedly
        /// taking the lightest edge that reaches a node not yet in the tree
        /// (found with a min-heap). The result links every reachable node
        /// with the smallest possible total edge weight.
        /// </summary>
        public SpanningTree MinimumSpanningTree(int start)
        {
            var steps = new List<TraversalStep>();
            if (!Contains(start))
            {
                return new SpanningTree(steps, 0);
            }

            var depthOf = new Dictionary<int, int> { [start] = 0 };
            steps.Add(new TraversalStep(start, null, 0, 0));
            var totalWeight = 0;

            var candidates = new BinaryHeap<(int Weight, int From, int To)>(
                Comparer<(int Weight, int From, int To)>.Create((a, b) =>
                {
                    var byWeight = a.Weight.CompareTo(b.Weight);
                    if (byWeight != 0) return byWeight;
                    var byTarget = a.To.CompareTo(b.To);
                    return byTarget != 0 ? byTarget : a.From.CompareTo(b.From);
                }));

            void PushEdgesOf(int node)
            {
                foreach (var (neighbour, weight) in _adjacency[node])
                {
                    if (!depthOf.ContainsKey(neighbour))
                    {
                        candidates.Push((weight, node, neighbour));
                    }
                }
            }

            PushEdgesOf(start);

            while (!candidates.IsEmpty)
            {
                var (weight, from, to) = candidates.Pop();
                if (depthOf.ContainsKey(to))
                {
                    continue;
                }

                var depth = depthOf[from] + 1;
                depthOf[to] = depth;
                steps.Add(new TraversalStep(to, from, depth, weight));
                totalWeight += weight;
                PushEdgesOf(to);
            }

            return new SpanningTree(steps, totalWeight);
        }
    }
}
