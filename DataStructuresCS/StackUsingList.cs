using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.List
{
    public class StackUsingList<T> : IEnumerable<T>
    {
        private System.Collections.Generic.LinkedList<T> _list = new LinkedList<T>();

        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        public T Pop()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("Stack is Empty");
            }
            T value = _list.First.Value;
           _list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Stack is Empty");
            }
            return _list.First.Value;
        }

        public int Count()
        {
            return _list.Count;
        }

        public void Clear()
        {
            _list.Clear();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
