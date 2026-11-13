namespace Municipal_Application.DataStructures
{
    /// <summary>
    /// A self-balancing binary search tree. After every insert the heights of
    /// each node's two subtrees differ by at most one; when they would differ
    /// by two, single or double rotations restore the balance. Height therefore
    /// stays O(log n) even when keys arrive in sorted order.
    /// </summary>
    public class AvlTree<TKey, TValue> : BinaryTree<TKey, TValue>
    {
        public AvlTree(IComparer<TKey>? comparer = null) : base(comparer)
        {
        }

        public override void Insert(TKey key, TValue value)
        {
            Root = Insert(Root, key, value);
            Count++;
        }

        /// <summary>Checks that every stored height is correct and no node is out of balance.</summary>
        public bool IsValid() => Validate(Root, out _);

        private BinaryTreeNode<TKey, TValue> Insert(BinaryTreeNode<TKey, TValue>? node, TKey key, TValue value)
        {
            if (node == null)
            {
                return new BinaryTreeNode<TKey, TValue>(key, value);
            }

            var comparison = Comparer.Compare(key, node.Key);
            if (comparison < 0)
            {
                node.Left = Insert(node.Left, key, value);
            }
            else if (comparison > 0)
            {
                node.Right = Insert(node.Right, key, value);
            }
            else
            {
                throw DuplicateKey();
            }

            return Rebalance(node);
        }

        private static BinaryTreeNode<TKey, TValue> Rebalance(BinaryTreeNode<TKey, TValue> node)
        {
            UpdateHeight(node);
            var balance = HeightOf(node.Left) - HeightOf(node.Right);

            if (balance > 1)
            {
                // Left-right case: straighten the left child first.
                if (HeightOf(node.Left!.Left) < HeightOf(node.Left.Right))
                {
                    node.Left = RotateLeft(node.Left);
                }

                return RotateRight(node);
            }

            if (balance < -1)
            {
                // Right-left case: straighten the right child first.
                if (HeightOf(node.Right!.Right) < HeightOf(node.Right.Left))
                {
                    node.Right = RotateRight(node.Right);
                }

                return RotateLeft(node);
            }

            return node;
        }

        private static BinaryTreeNode<TKey, TValue> RotateRight(BinaryTreeNode<TKey, TValue> node)
        {
            var pivot = node.Left!;
            node.Left = pivot.Right;
            pivot.Right = node;
            UpdateHeight(node);
            UpdateHeight(pivot);
            return pivot;
        }

        private static BinaryTreeNode<TKey, TValue> RotateLeft(BinaryTreeNode<TKey, TValue> node)
        {
            var pivot = node.Right!;
            node.Right = pivot.Left;
            pivot.Left = node;
            UpdateHeight(node);
            UpdateHeight(pivot);
            return pivot;
        }

        private static void UpdateHeight(BinaryTreeNode<TKey, TValue> node)
        {
            node.SubtreeHeight = 1 + Math.Max(HeightOf(node.Left), HeightOf(node.Right));
        }

        private static bool Validate(BinaryTreeNode<TKey, TValue>? node, out int height)
        {
            if (node == null)
            {
                height = 0;
                return true;
            }

            var leftValid = Validate(node.Left, out var leftHeight);
            var rightValid = Validate(node.Right, out var rightHeight);
            height = 1 + Math.Max(leftHeight, rightHeight);

            return leftValid && rightValid
                && Math.Abs(leftHeight - rightHeight) <= 1
                && node.SubtreeHeight == height;
        }
    }
}
