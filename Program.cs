using System;

namespace Task21MaxElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxArrayValue = int.MinValue;
            int replacementValue = 0;
            int minRandomValue = 10;
            int maxRandomValue = 99;

            int[,] array = new int[10, 10];
            Random rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(minRandomValue, maxRandomValue);
                    Console.Write(array[i, j] + " ");

                    if (array[i, j] > maxArrayValue)
                        maxArrayValue = array[i, j];
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Наибольший Элемент в массиве = " + maxArrayValue);
            Console.WriteLine();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maxArrayValue)
                    {
                        array[i, j] = replacementValue;
                        Console.Write(" " + array[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(array[i, j] + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
