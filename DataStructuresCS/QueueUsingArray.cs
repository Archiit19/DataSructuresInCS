using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue.Array
{
    public class QueueUsingArray<T> : IEnumerable<T>
    {
        T[] _items = new T[0];
        int _size = 0;
        int _head = 0;
        int _tail = -1;

        public void Enqueue(T item)
        {
            if(_items.Length == _size)
            {
                int newLength = (_size == 0) ? 4 : _size * 2;
                T[] newArray = new T[newLength];
                if (_size > 0)
                {
                    int targetIndex = 0;

                    if (_tail < _head)
                    {
                        for (int index = 0; index <= _head; index++)
                        {
                            newArray[targetIndex++] = _items[index];
                        }
                        for (int index = targetIndex; index <= _tail; index++)
                        {
                            newArray[targetIndex++] = _items[index];
                        }
                    }
                    else
                    {
                        for (int index = _head; index <= _tail; index++)
                        {
                            newArray[targetIndex++] = _items[index];
                        }
                    }
                    _head = 0;
                    _tail = targetIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }
                _items = newArray;
            }
            if(_tail == _items.Length -1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }
            _items[_tail] = item;
            _size++;
        }

        public void PrintQueue()
        {
            Console.Write("Queue is :  ");
            if(_tail < _head)
            {
                for (int index = _head; index < _items.Length; index++)
                {
                    Console.Write(" <- ");  Console.Write( _items[index]);
                }
                for (int index = 0; index <= _tail; index++)
                {
                    Console.Write(" <- ");  Console.Write(_items[index]);
                }
            }
            else
            {
                for(int index = _head; index <= _tail; index++)
                {
                    Console.Write(" <- ");  Console.Write(_items[index]);
                }
            }
            Console.WriteLine();
            
        }

        public T Dequeue()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException();
            }

            T value = _items[_head];

            if (_head == _items.Length-1)
            {
                _head = 0;
            }
            else
            {
                _head++;
            }
            
            _size--;
            return value;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }
            return _items[_head];
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if(_size > 0)
            {
                if(_tail<_head)
                {
                    for (int index = _head; index < _items.Length; index++)
                        yield return _items[index];
                
                    for (int index = 0; index <= _tail; index++)
                        yield return _items[index];
                }
                else
                {
                    for (int index = _head; index <= _tail; index++)
                        yield return _items[index];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class PriorityQueueUsingArray<T> : IEnumerable<T> where T:IComparable<T>
    {
        LinkedList<T> _items = new LinkedList<T>();

        int _size = 0;
        int _head = 0;
        int _tail = -1;

        public void Enqueue(T item)
        {
            if(_items.Count == 0)
            {
                _items.AddLast(item);
            }
            else
            {
                var current = _items.First;
                while(current != null && current.Value.CompareTo(item) > 0 )
                {
                    current = current.Next;
                }
                if(current == null)
                {
                    _items.AddLast(item);
                }
                else
                {
                    _items.AddBefore(current, item);
                }
            }
        }
        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }

            T value = _items.First.Value;
            _items.RemoveFirst();

            return value;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }
            return _items.First.Value;
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
