﻿using System;
using System.Linq;
using System.Text;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Lessons.Section8
{
    public class Lesson105SolutionReverse : IBaseLesson
    {
        private static readonly object[] _defaultArray = new object[] { 2, 5, 1, 3, 4 };

        public void Run()
        {
            var array = GetArray();
            if (array == null)
            {
                Console.WriteLine("Oops, invalid input");
                return;
            }

            var linkedList = new LinkedList(array);

            Console.WriteLine(linkedList);
            linkedList.Reverse();
            Console.WriteLine(linkedList);
        }

        private static object[] GetArray()
        {
            Console.Write("Input comma separated array (or press \"Enter\" for the default array): ");
            var input = Console.ReadLine().Trim();
            var array = _defaultArray;
            if (!string.IsNullOrEmpty(input))
            {
                array = input.Split(',').Select(c => c.Trim()).ToArray();
                if (array.Length == 0)
                {
                    return null;
                }
            }

            Console.Write("Input array is: " + array.ToPyString() + Environment.NewLine);
            return array;
        }
    }

    public class LinkedList
    {
        public LinkedList(params object[] initialValues)
        {
            if (initialValues == null)
            {
                throw new ArgumentNullException(nameof(initialValues));
            }

            var len = initialValues.Length;

            if (len == 0)
            {
                throw new ArgumentException("Length can't be zero");
            }

            Head = new Node(initialValues[0]);
            Tail = Head;

            for (var i = 1; i < len; i++)
            {
                Tail.Next = new Node(initialValues[i]);
                Tail = Tail.Next;
            }
        }

        public Node Head { get; set; }
        public Node Tail { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var current = Head;

            while (current != null)
            {
                sb.Append(current.Value);
                sb.Append(" ");
                current = current.Next;
            }

            return sb.ToString();
        }

        public LinkedList Reverse()
        {
            if (Head?.Next == null)
            {
                return this;
            }

            Tail = Head;

            Node previous = null;
            var current = Head;

            while (current != null)
            {
                var next = current?.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            Head = previous;
            
            return this;
        }

        public void ReverseRecursive()
        {
            ReverseInner(null, Head);
        }

        private void ReverseInner(Node previous, Node current)
        {
            if (current.Next == null)
            {
                Head = current;
            }
            else
            {
                ReverseInner(current, current.Next);
            }

            Tail = current;
            current.Next = previous;
        }
    }

    public class Node
    {
        public Node(object value, Node next = null)
        {
            Value = value;
            Next = next;
        }

        public object Value { get; set; }
        public Node Next { get; set; }
    }
}
