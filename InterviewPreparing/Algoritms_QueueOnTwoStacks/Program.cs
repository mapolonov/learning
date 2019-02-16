using System;
using System.Collections.Generic;

namespace Algoritms_QueueOnTwoStacks
{


    class Program
    {
        static void Main(string[] args)
        {
            QueueOnTwoStacks<int> q = new QueueOnTwoStacks<int>();
            q.add(1);
            q.add(10);
            q.add(2);
            Console.WriteLine(q.size());

            Console.WriteLine(q.peek());
        }
    }

    public class QueueOnTwoStacks<T>
    {
        private Stack<T> StackMain = new Stack<T>();
        private Stack<T> StackTemp = new Stack<T>();
        private T FirstInQueue;

        public QueueOnTwoStacks()
        {
        }

        public int size()
        {
            return StackMain.Count;
        }

        public void add(T value)
        {
            if (StackMain.Count == 0)
            {
                FirstInQueue = value;
            }
            StackMain.Push(value);
        }

        public T peek()
        {
            if (StackMain.Count != 0)
            {
                return FirstInQueue;
            }
            else return default(T);
        }

        public T remove()
        {
            if (StackMain.Count != 0)
            {
                StackTemp.Clear();

                T ret;

                if (StackMain.Count != 1)
                {
                    while (StackMain.Count != 1)
                    {
                        StackTemp.Push(StackMain.Pop());
                    }

                    ret = StackMain.Pop();

                    FirstInQueue = StackTemp.Peek();

                    StackMain.Clear();
                    while (StackTemp.Count != 0)
                    {
                        StackMain.Push(StackTemp.Pop());
                    }
                }
                else
                {
                    FirstInQueue = default(T);
                    ret = StackMain.Pop();
                }
                return ret;
            }
            else
                return StackMain.Pop();
        }
    }
}
