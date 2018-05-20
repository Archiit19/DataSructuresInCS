using System;
using System.Collections.Generic;
using SingleLinkedList;
using DoubleLinkedList;
using Stack.List;
using Queue.Array;
using Queue.List;

namespace DataStructuresCS
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LinkedList
            SingleLinkedList<int> singleLL = new SingleLinkedList<int>();
            SingleLinkedListNode<int> snode1 = new SingleLinkedListNode<int>(20);
            singleLL.AddFirst(snode1); singleLL.Add(30); singleLL.AddLast(90); singleLL.AddFirst(11);
            singleLL.PrintList("");

            DoubleLinkedList<int> doubleLL = new DoubleLinkedList<int>();
            DoubleLinkedListNode<int> node1 = new DoubleLinkedListNode<int>(45);
            doubleLL.AddFirst(node1); doubleLL.AddLast(90); doubleLL.Add(33); doubleLL.Add(30); doubleLL.Add(31);
            doubleLL.PrintList("");

            #endregion

            #region Stack
            // To Evaluate PostFix Expression.
            PostFixCalculator();
            #endregion

            #region Queue
            QueueUsingArray<int> queue1 = new QueueUsingArray<int>();
            queue1.Enqueue(50); queue1.Enqueue(60); queue1.Enqueue(70); queue1.Enqueue(80); queue1.Enqueue(90);
            queue1.Dequeue(); queue1.Dequeue();
            queue1.Enqueue(50); queue1.Enqueue(60); queue1.Enqueue(70); queue1.Enqueue(80); queue1.Enqueue(90);
            queue1.Dequeue(); queue1.Dequeue();
            queue1.PrintQueue();

            QueueUsingList<int> queue2 = new QueueUsingList<int>();
            queue2.Enqueue(50); queue2.Enqueue(60); queue2.Enqueue(70); queue2.Enqueue(80); queue2.Enqueue(90);
            queue2.Dequeue(); queue2.Dequeue();
            queue2.Enqueue(50); queue2.Enqueue(60); queue2.Enqueue(70); queue2.Enqueue(80); queue2.Enqueue(90);
            queue2.Dequeue(); queue2.Dequeue();
            queue2.PrintQueue();
            #endregion

            #region Trees




            #endregion


        }

        static void PostFixCalculator()
        {
            Console.Write("Enter the Postfix Expression : ");
            string[] postfixExpr = Console.ReadLine().Split(' ');

            StackUsingList<int> values = new StackUsingList<int>();
            foreach (string token in postfixExpr)
            {
                int value;
                if(int.TryParse(token.Trim(), out value))
                {
                    values.Push(value);
                }
                else
                {
                    int rhs = values.Pop();
                    int lhs = values.Pop();
                    switch(token)
                    {
                        case "+" :      values.Push(lhs + rhs); break;
                        case "-" :      values.Push(lhs - rhs); break;
                        case "*" :      values.Push(lhs * rhs); break;
                        case "/" :      values.Push(lhs / rhs); break;
                        default:        throw new ArgumentException(string.Format("Unrecognized token : {0} ", token));   
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine( string.Format("Output of Postfix Expression is : {0} ", values.Peek()) );
        }

    }
}
