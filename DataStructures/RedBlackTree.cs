namespace Municipal_Application.DataStructures
{
    /// <summary>
    /// A self-balancing binary search tree that colours every node red or
    /// black. Four rules keep it balanced: the root is black; a red node never
    /// has a red child; every path from a node down to a missing child passes
    /// the same number of black nodes. Inserting recolours and rotates to keep
    /// those rules, so the longest path is never more than twice the shortest.
    /// </summary>
    public class RedBlackTree<TKey, TValue> : BinaryTree<TKey, TValue>
    {
        public RedBlackTree(IComparer<TKey>? comparer = null) : base(comparer)
        {
        }

        public override void Insert(TKey key, TValue value)
        {
            var newNode = new BinaryTreeNode<TKey, TValue>(key, value) { Color = NodeColor.Red };

            BinaryTreeNode<TKey, TValue>? parent = null;
            var current = Root;
            var comparison = 0;

            while (current != null)
            {
                parent = current;
                comparison = Comparer.Compare(key, current.Key);
                if (comparison == 0)
                {
                    throw DuplicateKey();
                }

                current = comparison < 0 ? current.Left : current.Right;
            }

            newNode.Parent = parent;
            if (parent == null)
            {
                Root = newNode;
            }
            else if (comparison < 0)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }

            Count++;
            FixAfterInsert(newNode);
        }

        /// <summary>Checks all of the red-black rules and the parent links.</summary>
        public bool IsValid()
        {
            if (Root == null)
            {
                return true;
            }

            return Root.Color == NodeColor.Black && Root.Parent == null && Validate(Root, out _);
        }

        private void FixAfterInsert(BinaryTreeNode<TKey, TValue> node)
        {
            while (node.Parent != null && node.Parent.Color == NodeColor.Red)
            {
                // A red parent is never the root, so a grandparent always exists.
                var grandparent = node.Parent.Parent!;

                if (node.Parent == grandparent.Left)
                {
                    var uncle = grandparent.Right;
                    if (IsRed(uncle))
                    {
                        // Red uncle: push the blackness down from the grandparent.
                        node.Parent.Color = NodeColor.Black;
                        uncle!.Color = NodeColor.Black;
                        grandparent.Color = NodeColor.Red;
                        node = grandparent;
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }

                        node.Parent!.Color = NodeColor.Black;
                        node.Parent.Parent!.Color = NodeColor.Red;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    var uncle = grandparent.Left;
                    if (IsRed(uncle))
                    {
                        node.Parent.Color = NodeColor.Black;
                        uncle!.Color = NodeColor.Black;
                        grandparent.Color = NodeColor.Red;
                        node = grandparent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }

                        node.Parent!.Color = NodeColor.Black;
                        node.Parent.Parent!.Color = NodeColor.Red;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }

            Root!.Color = NodeColor.Black;
        }

        private void RotateLeft(BinaryTreeNode<TKey, TValue> node)
        {
            var pivot = node.Right!;
            node.Right = pivot.Left;
            if (pivot.Left != null)
            {
                pivot.Left.Parent = node;
            }

            ReplaceInParent(node, pivot);
            pivot.Left = node;
            node.Parent = pivot;
        }

        private void RotateRight(BinaryTreeNode<TKey, TValue> node)
        {
            var pivot = node.Left!;
            node.Left = pivot.Right;
            if (pivot.Right != null)
            {
                pivot.Right.Parent = node;
            }

            ReplaceInParent(node, pivot);
            pivot.Right = node;
            node.Parent = pivot;
        }

        private void ReplaceInParent(BinaryTreeNode<TKey, TValue> oldNode, BinaryTreeNode<TKey, TValue> newNode)
        {
            newNode.Parent = oldNode.Parent;
            if (oldNode.Parent == null)
            {
                Root = newNode;
            }
            else if (oldNode == oldNode.Parent.Left)
            {
                oldNode.Parent.Left = newNode;
            }
            else
            {
                oldNode.Parent.Right = newNode;
            }
        }

        private static bool IsRed(BinaryTreeNode<TKey, TValue>? node) => node?.Color == NodeColor.Red;

        /// <summary>Returns the black-height of the subtree, or false if any rule is broken.</summary>
        private static bool Validate(BinaryTreeNode<TKey, TValue>? node, out int blackHeight)
        {
            if (node == null)
            {
                blackHeight = 1;
                return true;
            }

            if (node.Left != null && node.Left.Parent != node) { blackHeight = 0; return false; }
            if (node.Right != null && node.Right.Parent != node) { blackHeight = 0; return false; }

            if (node.Color == NodeColor.Red && (IsRed(node.Left) || IsRed(node.Right)))
            {
                blackHeight = 0;
                return false;
            }

            var leftValid = Validate(node.Left, out var leftBlack);
            var rightValid = Validate(node.Right, out var rightBlack);
            blackHeight = leftBlack + (node.Color == NodeColor.Black ? 1 : 0);

            return leftValid && rightValid && leftBlack == rightBlack;
        }
    }
}
