using System.Diagnostics.CodeAnalysis;

namespace Municipal_Application.DataStructures
{
    /// <summary>
    /// A binary tree whose keys are kept in sorted order. This base class holds
    /// everything the binary search tree, AVL tree and red-black tree have in
    /// common: searching, the four classic traversals, range queries and
    /// height. Each subclass only decides how a new key is inserted and how
    /// the tree keeps itself balanced.
    /// </summary>
    public abstract class BinaryTree<TKey, TValue>
    {
        protected BinaryTree(IComparer<TKey>? comparer)
        {
            Comparer = comparer ?? Comparer<TKey>.Default;
        }

        protected IComparer<TKey> Comparer { get; }

        protected BinaryTreeNode<TKey, TValue>? Root { get; set; }

        public int Count { get; protected set; }

        /// <summary>Adds a key. Throws <see cref="ArgumentException"/> if the key already exists.</summary>
        public abstract void Insert(TKey key, TValue value);

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            var current = Root;
            while (current != null)
            {
                var comparison = Comparer.Compare(key, current.Key);
                if (comparison == 0)
                {
                    value = current.Value;
                    return true;
                }

                current = comparison < 0 ? current.Left : current.Right;
            }

            value = default;
            return false;
        }

        public bool ContainsKey(TKey key) => TryGetValue(key, out _);

        /// <summary>Number of levels in the tree (0 for an empty tree).</summary>
        public int Height
        {
            get
            {
                if (Root == null)
                {
                    return 0;
                }

                var height = 0;
                var level = new Queue<BinaryTreeNode<TKey, TValue>>();
                level.Enqueue(Root);

                while (level.Count > 0)
                {
                    height++;
                    for (var remaining = level.Count; remaining > 0; remaining--)
                    {
                        var node = level.Dequeue();
                        if (node.Left != null) level.Enqueue(node.Left);
                        if (node.Right != null) level.Enqueue(node.Right);
                    }
                }

                return height;
            }
        }

        public bool TryGetMinimum(out TKey key, out TValue value)
        {
            if (Root == null)
            {
                key = default!;
                value = default!;
                return false;
            }

            var node = Root;
            while (node.Left != null) node = node.Left;
            key = node.Key;
            value = node.Value;
            return true;
        }

        public bool TryGetMaximum(out TKey key, out TValue value)
        {
            if (Root == null)
            {
                key = default!;
                value = default!;
                return false;
            }

            var node = Root;
            while (node.Right != null) node = node.Right;
            key = node.Key;
            value = node.Value;
            return true;
        }

        /// <summary>Left, node, right: yields the keys in ascending order.</summary>
        public IEnumerable<KeyValuePair<TKey, TValue>> InOrder()
        {
            var stack = new Stack<BinaryTreeNode<TKey, TValue>>();
            var current = Root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                yield return new KeyValuePair<TKey, TValue>(current.Key, current.Value);
                current = current.Right;
            }
        }

        /// <summary>Node, left, right.</summary>
        public IEnumerable<KeyValuePair<TKey, TValue>> PreOrder()
        {
            if (Root == null)
            {
                yield break;
            }

            var stack = new Stack<BinaryTreeNode<TKey, TValue>>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return new KeyValuePair<TKey, TValue>(node.Key, node.Value);
                if (node.Right != null) stack.Push(node.Right);
                if (node.Left != null) stack.Push(node.Left);
            }
        }

        /// <summary>Left, right, node.</summary>
        public IEnumerable<KeyValuePair<TKey, TValue>> PostOrder()
        {
            if (Root == null)
            {
                yield break;
            }

            var pending = new Stack<BinaryTreeNode<TKey, TValue>>();
            var output = new Stack<BinaryTreeNode<TKey, TValue>>();
            pending.Push(Root);

            while (pending.Count > 0)
            {
                var node = pending.Pop();
                output.Push(node);
                if (node.Left != null) pending.Push(node.Left);
                if (node.Right != null) pending.Push(node.Right);
            }

            while (output.Count > 0)
            {
                var node = output.Pop();
                yield return new KeyValuePair<TKey, TValue>(node.Key, node.Value);
            }
        }

        /// <summary>Breadth-first, one level at a time from the root.</summary>
        public IEnumerable<KeyValuePair<TKey, TValue>> LevelOrder()
        {
            if (Root == null)
            {
                yield break;
            }

            var queue = new Queue<BinaryTreeNode<TKey, TValue>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return new KeyValuePair<TKey, TValue>(node.Key, node.Value);
                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }

        /// <summary>
        /// Every entry with <paramref name="low"/> &lt;= key &lt;= <paramref name="high"/>, in ascending order.
        /// Whole subtrees outside the range are skipped, so this costs O(height + matches).
        /// </summary>
        public IEnumerable<KeyValuePair<TKey, TValue>> Range(TKey low, TKey high)
        {
            var stack = new Stack<BinaryTreeNode<TKey, TValue>>();
            var current = Root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    if (Comparer.Compare(current.Key, low) >= 0)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                    else
                    {
                        // This node and everything to its left is below the range.
                        current = current.Right;
                    }
                }

                if (stack.Count == 0)
                {
                    yield break;
                }

                current = stack.Pop();
                if (Comparer.Compare(current.Key, high) > 0)
                {
                    yield break;
                }

                yield return new KeyValuePair<TKey, TValue>(current.Key, current.Value);
                current = current.Right;
            }
        }

        protected static int HeightOf(BinaryTreeNode<TKey, TValue>? node) => node?.SubtreeHeight ?? 0;

        protected static ArgumentException DuplicateKey() =>
            new("An entry with the same key already exists in the tree.");
    }
}
