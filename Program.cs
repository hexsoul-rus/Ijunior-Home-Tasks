using System;

namespace Task24LongestArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minRandomValue = 5;
            int maxRandomValue = 10;
            int maxRepeatCount = 0;
            int minRepeatCount = 1;
            int repeatCount  = 0;
            int maxRepeatedValue = 0;
            int repeatedValue = maxRandomValue;
            bool hasMaxRepeatedValue = false;
            int[] array = new int[30];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandomValue, maxRandomValue);
                Console.Write(array[i] + " ");
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (repeatedValue == array[i])
                {
                    repeatCount++;
                }
                else
                {
                    repeatedValue = array[i];
                    repeatCount = minRepeatCount;
                }

                if (repeatCount > maxRepeatCount)
                {
                    maxRepeatCount = repeatCount;
                    maxRepeatedValue = repeatedValue;
                    hasMaxRepeatedValue = true;
                }
                else if (repeatCount == maxRepeatCount)
                {
                    hasMaxRepeatedValue = false;
                }
            }

            if (maxRepeatCount > minRepeatCount && hasMaxRepeatedValue)
                Console.WriteLine($"\nЧисло {maxRepeatedValue} повторяется большее количество раз подряд {maxRepeatCount}.");
            else if (maxRepeatCount > minRepeatCount)
                Console.WriteLine($"\nВ массиве имеется несколько чисел с наибольшим количеством повторений, одно из них {maxRepeatedValue} повторяется {maxRepeatCount} раза.");
            else
                Console.WriteLine("\nВ массиве нет повторяющихся подряд чисел.");
        }
    }
}
