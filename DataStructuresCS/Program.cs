using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList;
using DoubleLinkedList;
using Stack.List;

namespace DataStructuresCS
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList<int> singleLL = new SingleLinkedList<int>();
            SingleLinkedListNode<int> snode1 = new SingleLinkedListNode<int>(20);
            singleLL.AddFirst(snode1); singleLL.Add(30); singleLL.AddLast(90); singleLL.AddFirst(11);
            singleLL.PrintList();

            DoubleLinkedList<int> doubleLL = new DoubleLinkedList<int>();
            DoubleLinkedListNode<int> node1 = new DoubleLinkedListNode<int>(45);
            doubleLL.AddFirst(node1); doubleLL.AddLast(90); doubleLL.Add(33); doubleLL.Add(30); doubleLL.Add(31);
            doubleLL.PrintList();

            // To Evaluate PostFix Expression.
            PostFixCalculator();
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
