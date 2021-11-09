using System;
using System.Collections.Generic;

namespace HashTables
{
    class Program
    {
        static void Main(string[] args)
        {
            NodeMap<string, string> hashTable = new NodeMap<string, string>(5);
            hashTable.Add("0","To");
            hashTable.Add("1","be");
            hashTable.Add("2","or");
            hashTable.Add("3","not");
            hashTable.Add("4","to");
            hashTable.Add("5", "be");
            string hashTable5 = hashTable.Get("5");
            Console.WriteLine("5 Value = " + hashTable5);
            string hashTable2 = hashTable.Get("2");
            Console.WriteLine("2 Value = " + hashTable2);
        }
    }
}
