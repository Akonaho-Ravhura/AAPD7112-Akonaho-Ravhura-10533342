namespace Municipal_Application.DataStructures
{
    /// <summary>
    /// An array-backed binary heap. The item the comparer ranks first is always
    /// at the top, so peeking is O(1) and pushing/popping are O(log n).
    /// For a max-heap, pass a comparer that ranks larger values first.
    /// </summary>
    public class BinaryHeap<T>
    {
        private readonly List<T> _items;
        private readonly IComparer<T> _comparer;

        public BinaryHeap(IComparer<T>? comparer = null)
        {
            _items = new List<T>();
            _comparer = comparer ?? Comparer<T>.Default;
        }

        /// <summary>Builds a heap from existing items in O(n) by sifting down from the middle.</summary>
        public BinaryHeap(IEnumerable<T> items, IComparer<T>? comparer = null)
        {
            _items = new List<T>(items);
            _comparer = comparer ?? Comparer<T>.Default;

            for (var index = _items.Count / 2 - 1; index >= 0; index--)
            {
                SiftDown(index);
            }
        }

        public int Count => _items.Count;

        public bool IsEmpty => _items.Count == 0;

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            return _items[0];
        }

        public void Push(T item)
        {
            _items.Add(item);
            SiftUp(_items.Count - 1);
        }

        public T Pop()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            var top = _items[0];
            var last = _items[^1];
            _items.RemoveAt(_items.Count - 1);

            if (_items.Count > 0)
            {
                _items[0] = last;
                SiftDown(0);
            }

            return top;
        }

        /// <summary>The first <paramref name="count"/> items in priority order, leaving this heap untouched.</summary>
        public List<T> PeekTop(int count)
        {
            var copy = new BinaryHeap<T>(_items, _comparer);
            var result = new List<T>();
            while (copy.Count > 0 && result.Count < count)
            {
                result.Add(copy.Pop());
            }

            return result;
        }

        /// <summary>Every item in priority order (a heap sort), leaving this heap untouched.</summary>
        public List<T> ToSortedList() => PeekTop(_items.Count);

        private void SiftUp(int index)
        {
            while (index > 0)
            {
                var parent = (index - 1) / 2;
                if (_comparer.Compare(_items[index], _items[parent]) >= 0)
                {
                    break;
                }

                Swap(index, parent);
                index = parent;
            }
        }

        private void SiftDown(int index)
        {
            while (true)
            {
                var left = 2 * index + 1;
                var right = left + 1;
                var best = index;

                if (left < _items.Count && _comparer.Compare(_items[left], _items[best]) < 0)
                {
                    best = left;
                }

                if (right < _items.Count && _comparer.Compare(_items[right], _items[best]) < 0)
                {
                    best = right;
                }

                if (best == index)
                {
                    return;
                }

                Swap(index, best);
                index = best;
            }
        }

        private void Swap(int first, int second)
        {
            (_items[first], _items[second]) = (_items[second], _items[first]);
        }
    }
}
