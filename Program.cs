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

            foreach (string item in strings1) 
                Console.Write(item + " ");

            Console.Write( " + ");

            foreach (string item in strings2) 
                Console.Write(item + " ");

            AddUniqueStrings(strings1, mergedStrings);
            AddUniqueStrings(strings2, mergedStrings);
            Console.Write(" => ");

            foreach (var item in mergedStrings)  
                Console.Write(item + " ");
        }

        static void AddUniqueStrings(string[] targetStrings, List<string> uniqueStrings)
        {
            for (int i = 0; i < targetStrings.Length; i++)
            {
                bool isUnique = true;

                foreach (string item in uniqueStrings)
                {
                    if (item == targetStrings[i])
                    {
                        isUnique = false;
                        break;
                    }
                }

                if (isUnique)
                {
                    uniqueStrings.Add(targetStrings[i]);
                }
            }
        }
    }
}
