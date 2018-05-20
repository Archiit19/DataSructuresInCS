using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList;

namespace Queue.List
{
    public class QueueUsingList<T> : IEnumerable<T>
    {
        private SingleLinkedList<T> _items = new SingleLinkedList<T>();

        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }

        public T Dequeue()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("The Queue is Empty");
            }
            T value = _items.Head.Value;
            _items.RemoveFirst();
            return value;
        }

        public void PrintQueue()
        {
            Console.Write("Queue using Single Linked List is : ");

            SingleLinkedListNode<T> current = _items.Head;
            while (current != null)
            {
                Console.Write( " <- " + current.Value );
                current = current.Next;
            }
            Console.WriteLine();
        }
        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The Queue is Empty");
            }
            return _items.Head.Value;
        }

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
