namespace ReversingLinkedListRecursively
{
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
