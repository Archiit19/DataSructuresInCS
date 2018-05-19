using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    public class SingleLinkedListNode<T>
    {
        public SingleLinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public SingleLinkedListNode<T> Next { get; set; }
        
    }

  
}
