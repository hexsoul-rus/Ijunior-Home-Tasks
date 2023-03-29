using System;

namespace Task32Shuffle
{
    internal class Program
    {
        static void ShuffleArray(int[] array)
        {
            Random random = new();

            for (int i = 0; i < array.Length - 1; i++)
            {
                int randomIndex = random.Next(i + 1, array.Length - 1);
                int tmp = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = tmp;
            }
        }

        static void Main()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            ShuffleArray(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
