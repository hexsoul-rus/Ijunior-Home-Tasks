using System;
using System.Collections.Generic;

namespace Task37MergingCollections
{
    internal class Program
    {
        static void Main()
        {
            string[] strings1 = new string[] { "2", "4", "1", "1" };
            string[] strings2 = new string[] { "4", "7", "2", "3", "2" };
            List<string> mergedStrings = new();

            WriteCollectionToConsole(strings1);
            Console.Write(" + ");
            WriteCollectionToConsole(strings2);
            AddUniqueStrings(strings1, mergedStrings);
            AddUniqueStrings(strings2, mergedStrings);
            Console.Write(" => ");
            WriteCollectionToConsole(mergedStrings.ToArray());
        }

        private static void WriteCollectionToConsole(string[] strings)
        {
            foreach (string value in strings)
                Console.Write(value + " ");
        }

        static void AddUniqueStrings(String[] targetStrings, List<string> uniqueStrings)
        {
            foreach(string value in targetStrings)
                if (uniqueStrings.Contains(value) == false)
                    uniqueStrings.Add(value);
        }
    }
}
