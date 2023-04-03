using System;
using System.Linq;

namespace HashTable
{
    public class StringsDictionary
    {
        private int _bucketssize = 10;

        private LinkedList[] _buckets = new LinkedList[10];
        
        public void Add(string key, string value)
        {
            var hash = CalculateHash(key);
            if (_buckets[hash] == null) _buckets[hash] = new LinkedList();
            _buckets[hash].Add(new KeyValuePair(key, value));
            if (_buckets[hash].Length() >= _bucketssize * 2)
            {
                _bucketssize*=2;
                Array.Resize(ref _buckets, _bucketssize);
                for (int i = 0; i < _bucketssize / 2; i++)
                {
                    var tempList = _buckets[i];
                    var pointer = tempList.First();
                    _buckets[i] = new LinkedList();
                    while (pointer.Next != null)
                    {
                        hash = CalculateHash(pointer.Pair.Key);
                        if (_buckets[hash] == null) _buckets[hash] = new LinkedList();
                        _buckets[hash].Add(pointer.Pair);
                        pointer = pointer.Next;
                    }
                }
            }
        }

        public void Remove(string key)
        {
            var hash = CalculateHash(key);
            _buckets[hash].RemoveByKey(key);
        }

        public string Get(string key)
        {
            var hash = CalculateHash(key);
            if(_buckets[hash].GetItemWithKey(key) != null) return _buckets[hash].GetItemWithKey(key).Value;
            return null;
        }


        private int CalculateHash(string key)
        {
            // function to convert string value to number
            double hash = 1;
            foreach (char s in key)
            {
                hash *= (int)s;
            }

            string strhash = hash.ToString("F").TrimEnd(new char[]{',','0'});
            strhash = new string(strhash.Take(4).ToArray());
            return Int32.Parse(strhash) % _bucketssize;
        }
    }
}