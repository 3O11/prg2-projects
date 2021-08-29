using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapLibrary
{
    class HeapItem<T>
    {

        public int cost;
        public T obj;

        public HeapItem(int cost, T o)
        {
            this.cost = cost;
            this.obj = o;
        }

    }

    public class Heap<T>
    {

        List<HeapItem<T>> heap = new List<HeapItem<T>>();

        Dictionary<T, HeapItem<T>> items = new Dictionary<T, HeapItem<T>>();

        public bool Contains(T o)
        {
            return items.ContainsKey(o);
        }

        public void Add(int cost, T o)
        {
            if (Contains(o))
            {
                ChangeCost(cost, o);
                return;
            }

            HeapItem<T> item = new HeapItem<T>(cost, o);

            heap.Add(item);
            items.Add(o, item);

            MoveUp(heap.Count() - 1);
        }

        public void ChangeCost(int cost, T o)
        {
            for (int i = 0; i < heap.Count(); ++i)
            {
                HeapItem<T> item = heap[i];
                if (ReferenceEquals(item.obj, o))
                {
                    if (item.cost == cost) return;
                    if (item.cost > cost)
                    {
                        item.cost = cost;
                        MoveDown(i);
                    }
                    else
                    {
                        item.cost = cost;
                        MoveUp(i);
                    }
                    return;
                }
            }
        }

        public T Top()
        {
            if (heap.Count() == 0) return default(T);
            return heap[0].obj;
        }

        public T Pop()
        {
            if (heap.Count() == 0) return default(T);

            T first = Top();
            items.Remove(first);

            if (heap.Count() == 1)
            {
                heap.RemoveAt(0);
                return first;
            }

            heap[0] = heap[heap.Count() - 1];
            heap.RemoveAt(heap.Count() - 1);

            MoveDown(0);

            return first;
        }

        private void MoveUp(int index)
        {
            if (index == 0) return;
            HeapItem<T> i1 = heap[index];
            HeapItem<T> i2 = heap[index / 2];
            if (i1.cost < i2.cost)
            {
                heap[index / 2] = i1;
                heap[index] = i2;
                MoveUp(index / 2);
            }
        }

        private void MoveDown(int index)
        {
            if (index >= heap.Count()) return;
            HeapItem<T> i1 = heap[index];

            HeapItem<T> i2 = (index * 2 < heap.Count() ? heap[index * 2] : null);
            HeapItem<T> i3 = (index * 2 + 1 < heap.Count() ? heap[index * 2 + 1] : null);

            if (i2 == null)
            {
                if (i3 == null)
                {
                    return;
                }
                if (i1.cost > i3.cost)
                {
                    heap[index] = i2;
                    heap[index * 2 + 1] = i1;
                    MoveDown(index * 2 + 1);
                }
                return;
            }

            if (i3 == null)
            {
                if (i1.cost > i2.cost)
                {
                    heap[index] = i2;
                    heap[index * 2] = i3;
                    MoveDown(index * 2);
                }
                return;
            }

            if (i1.cost <= i2.cost && i1.cost <= i2.cost)
            {
                return;
            }

            if (i2.cost > i3.cost)
            {
                heap[index] = i3;
                heap[index * 2 + 1] = i1;
                MoveDown(index * 2 + 1);
            }
            else
            {
                heap[index] = i2;
                heap[index * 2 + 1] = i1;
                MoveDown(index * 2);
            }

        }

    }

}
