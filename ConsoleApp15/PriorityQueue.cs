using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class PriorityQueue<T>
    {
        private List<T> heap = new List<T>();
        private readonly Comparison<T> comparison;

        public int Count => heap.Count;

        public PriorityQueue(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        public void Enqueue(T item)
        {
            heap.Add(item);
            int i = Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (comparison(heap[parent], heap[i]) <= 0)
                    break;

                Swap(parent, i);
                i = parent;
            }
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            T result = heap[0];
            int last = Count - 1;
            heap[0] = heap[last];
            heap.RemoveAt(last);

            int i = 0;
            while (true)
            {
                int leftChild = i * 2 + 1;
                if (leftChild >= last)
                    break;

                int rightChild = leftChild + 1;
                int minChild = (rightChild < last && comparison(heap[rightChild], heap[leftChild]) < 0) ? rightChild : leftChild;

                if (comparison(heap[i], heap[minChild]) <= 0)
                    break;

                Swap(i, minChild);
                i = minChild;
            }

            return result;
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
