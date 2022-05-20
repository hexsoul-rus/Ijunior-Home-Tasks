using System;

namespace Task22LocalMax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minRandomValue = 10;
            int maxRandomValue = 100;
            int offset = 1;

            int[] array = new int[32];
            Random random = new Random();
            array[0] = int.MinValue;
            array[array.Length - offset] = int.MinValue;

            for (int i = offset; i < array.Length - offset; i++) 
            {
                array[i] = random.Next(minRandomValue,maxRandomValue);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.Write("локальные максимумы: ");

            for (int i = offset; i < array.Length - offset; i++)
            {
                if (array[i] > array[i - offset] && array[i] > array[i + offset])
                    Console.Write(array[i] + " ");
            }
        }
    }
}
