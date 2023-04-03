using System;
using System.IO;

namespace HashTable
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
            var mylist = new LinkedList();
            mylist.Add(new KeyValuePair("key1", "value1"));
            mylist.Add(new KeyValuePair("key2", "value2"));
            mylist.Add(new KeyValuePair("key3", "value3"));
            mylist.Print();
            mylist.AddAfterByKey(new KeyValuePair("key4", "value4"), "key1");
            mylist.AddAfterByKey(new KeyValuePair("key5", "value5"), "key2");
            mylist.Print();
            */
            
            
            
            
            var dictionary = new StringsDictionary();
            foreach (var line in File.ReadAllLines(@"C:\Users\sania\RiderProjects\HashTable\HashTable\dictionary.txt"))
            {
                string[] splited = line.Split(new char[] { ';' }, 2);
                dictionary.Add(splited[0], splited[1]);
            }

            Console.WriteLine("enter:");
            while (true)
            {
                var request = Console.ReadLine();
                Console.WriteLine(dictionary.Get(request));
            }
        }
    }
}