using System.Collections.Generic;
using System.Linq;

namespace ReversingLinkedListRecursively
{
    class LinkedList
    {
        private Entry _head;

        private Entry _last;

        public bool IsEmpty => _head == null;

        public void Append(Entry newEntry)
        {
            if (IsEmpty)
            {
                _head = _last = newEntry;
            }
            else
            {
                _last.Next = newEntry;
                _last = newEntry;
            }
        }

        // returns null for the empty list.
        public Entry EvictLastEntry()
        {
            var preLast = GetEnumerableOfEntry().Where(e => e.Next == _last).SingleOrDefault();
            var evicted = _last;
            if (preLast == null)
            {
                _last = _head = null;
            }
            else
            {
                preLast.Next = null;
                _last = preLast;
            }
            return evicted;
        }

        public IEnumerable<Entry> GetEnumerableOfEntry()
        {
            for (var e = _head; e != null; e = e.Next)
            {
                yield return e;
            }
        }
    }
}
