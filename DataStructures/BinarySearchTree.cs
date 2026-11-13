namespace Municipal_Application.DataStructures
{
    /// <summary>
    /// A plain (unbalanced) binary search tree: smaller keys go left, larger
    /// keys go right. Searching is fast while the keys arrive in a mixed order,
    /// but it can degrade into a linked list if keys arrive already sorted,
    /// which is exactly the problem the AVL and red-black trees solve.
    /// </summary>
    public class BinarySearchTree<TKey, TValue> : BinaryTree<TKey, TValue>
    {
        public BinarySearchTree(IComparer<TKey>? comparer = null) : base(comparer)
        {
        }

        public override void Insert(TKey key, TValue value)
        {
            var newNode = new BinaryTreeNode<TKey, TValue>(key, value);

            if (Root == null)
            {
                Root = newNode;
                Count = 1;
                return;
            }

            var current = Root;
            while (true)
            {
                var comparison = Comparer.Compare(key, current.Key);
                if (comparison == 0)
                {
                    throw DuplicateKey();
                }

                if (comparison < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = newNode;
                        break;
                    }

                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = newNode;
                        break;
                    }

                    current = current.Right;
                }
            }

            Count++;
        }
    }
}
