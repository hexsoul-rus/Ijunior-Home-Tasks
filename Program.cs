using System;

namespace Task16Multiples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minNValue = 1;
            int maxNValue = 28;
            int minMultiple = 100;
            int maxMultiple = 999;
            int multiplesCount = 0;
            int randomNValue;
            int multipleValue;

            Random rand = new Random();
            randomNValue = rand.Next(minNValue, maxNValue);
            multipleValue = randomNValue;

            while (multipleValue < minMultiple)
            {
                multipleValue += randomNValue;
            }

            while (multipleValue < maxMultiple)
            {
                multipleValue += randomNValue;
                multiplesCount++;
            }

            Console.WriteLine("Количество трехзначных натуральных чисел, которые кратны " + randomNValue + " = " + multiplesCount);
            Console.ReadLine();
        }
    }
}
