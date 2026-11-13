namespace Municipal_Application.DataStructures
{
    public enum NodeColor
    {
        Red,
        Black
    }

    /// <summary>
    /// A single node shared by every binary tree in this project.
    /// <see cref="Parent"/> and <see cref="Color"/> are only maintained by the
    /// red-black tree; <see cref="SubtreeHeight"/> only by the AVL tree.
    /// </summary>
    public class BinaryTreeNode<TKey, TValue>
    {
        public BinaryTreeNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; }

        public TValue Value { get; set; }

        public BinaryTreeNode<TKey, TValue>? Left { get; set; }

        public BinaryTreeNode<TKey, TValue>? Right { get; set; }

        public BinaryTreeNode<TKey, TValue>? Parent { get; set; }

        public int SubtreeHeight { get; set; } = 1;

        public NodeColor Color { get; set; } = NodeColor.Red;
    }
}
