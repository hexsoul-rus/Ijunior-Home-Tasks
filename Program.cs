using System;

namespace Task26Split
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordsLine = "каждый охотник желает знать где сидит фазан";
            string[] words;

            words = wordsLine.Split(' ');

            foreach (string word in words)
                Console.WriteLine(word);
        }
    }
}
