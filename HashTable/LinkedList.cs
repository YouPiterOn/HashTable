using System;
using System.Reflection;

namespace HashTable
{
    
    public class KeyValuePair
    {
        public string Key { get; }

        public string Value { get; }

        public KeyValuePair(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
    
    public class LinkedListNode
    {
        public KeyValuePair Pair { get; }
        
        public LinkedListNode Next { get; set; }

        public LinkedListNode(KeyValuePair pair, LinkedListNode next = null)
        {
            Pair = pair;
            Next = next;
        }
    }
    
    public class LinkedList
    {
        private LinkedListNode _first;
        private LinkedListNode _last;

        public void Add(KeyValuePair pair)
        {
            // add provided pair to the end of the linked list
            if (_first == null)
            {
                _first = new LinkedListNode(pair);
                _last = _first;
            }
            else
            {
                _last.Next = new LinkedListNode(pair);
                _last = _last.Next;
            }
        }
        
        public void AddAfterByKey(KeyValuePair pair, string key)
        {
            var pointer = _first;
            while (pointer.Pair.Key != key)
            {
                pointer = pointer.Next;
                if(pointer == null) return;
            }
            var temp = pointer.Next;
            pointer.Next = new LinkedListNode(pair);
            pointer.Next.Next = temp;
        }

        public void RemoveByKey(string key)
        {
            // remove pair with provided key
            var pointer = _first;
            if (pointer.Pair.Key == key)
                _first = pointer.Next;
            else
            {
                while (pointer.Next.Pair.Key != key)
                {
                    pointer = pointer.Next;
                    if(pointer.Next == null) return;
                }
                pointer.Next = pointer.Next.Next;
            }
        }

        public KeyValuePair GetItemWithKey(string key)
        {
            // get pair with provided key, return null if not found
            var pointer = _first;
            while (pointer.Pair.Key != key)
            {
                if (pointer.Next == null)
                    return null;
                pointer = pointer.Next;
            }
            return pointer.Pair;
        }

        public void Print()
        {
            var pointer = _first;
            while (pointer != null)
            {
                Console.WriteLine(pointer.Pair.Key+", "+pointer.Pair.Value);
                pointer = pointer.Next;
            }
        }

        public int Length()
        {
            var pointer = _first;
            int count = 0;
            while (pointer != null)
            {
                count++;
                pointer = pointer.Next;
            }
            return count;
        }

        public LinkedListNode First()
        {
            return _first;
        }
    }
}