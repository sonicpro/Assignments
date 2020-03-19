using System;
using System.Linq;

namespace ReversingLinkedListRecursively
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList();
            linkedList.Append(new Entry("A"));
            linkedList.Append(new Entry("B"));
            linkedList.Append(new Entry("C"));

            Console.WriteLine("The original list entries:");
            Console.WriteLine("--------------------------");
            linkedList.GetEnumerableOfEntry().ToList().ForEach(e => Console.WriteLine(e.Value));

            var reversedList = new LinkedList();
            ReverseLinkedList(linkedList, reversedList);
            Console.WriteLine();
            Console.WriteLine("The reversed list entries:");
            Console.WriteLine("--------------------------");
            reversedList.GetEnumerableOfEntry().ToList().ForEach(e => Console.WriteLine(e.Value));
        }

        static void ReverseLinkedList(LinkedList from, LinkedList to)
        {
            if (from.IsEmpty)
            {
                return;
            }
            var lastEntry = from.EvictLastEntry();
            to.Append(lastEntry);
            ReverseLinkedList(from, to);
        }
    }
}
