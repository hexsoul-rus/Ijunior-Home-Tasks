using System;

namespace Task32Shuffle
{
    internal class Program
    {
        static void ShuffleArray(int[] numbers)
        {
            Random random = new();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int randomIndex = random.Next(i + 1, numbers.Length - 1);
                int temporaryNumber = numbers[randomIndex];
                numbers[randomIndex] = numbers[i];
                numbers[i] = temporaryNumber;
            }
        }

        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            string numbersLine = string.Join(" ", numbers);
            Console.WriteLine("Normal: " + numbersLine);
            ShuffleArray(numbers);
            numbersLine = string.Join(" ", numbers);
            Console.Write("Shuffle: " + numbersLine);
        }
    }
}
