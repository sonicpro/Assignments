using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ll = new Entry("1")
            {
                Next = new Entry("2")
                {
                    Next = new Entry("3")
                }
            };
            var revertedList = Revert(ll);
            var head = revertedList;
            while (head != null)
            {
                Console.WriteLine(head.Value);
                head = head.Next;
            }
        }

        static Entry Revert(Entry current)
        {
            if (current.Next == null)
            {
                return current;
            }
            else
            {
                var newHead = Revert(current.Next);
                current.Next.Next = current;
                current.Next = null;
                return newHead;
            }
        }
    }

    public class Entry
    {
        public string Value { get; }

        public Entry Next { get; set; }

        public Entry(string value)
        {
            Value = value;
        }
    }
}
