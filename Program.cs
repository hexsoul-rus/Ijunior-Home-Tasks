using System;

namespace Task27Shift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int shift;
            int shiftedValue;
            int startIndex = 0;
            int index = 0;

            foreach (int i in array)
                Console.Write(i + " ");

            Console.Write("\nНа сколько сдвинуть значения? ");
            shift = Convert.ToInt32(Console.ReadLine());
            shiftedValue = array[index];

            for (int i = 0; i < array.Length - 1; i++)
            {
                index -= shift;

                if (index < 0)
                    index += array.Length;

                int tempValue = array[index];
                array[index] = shiftedValue;
                shiftedValue = tempValue;

                if (index == startIndex)
                {
                    index++;
                    startIndex = index;
                    shiftedValue = array[startIndex];
                }
            }

            array[startIndex] = shiftedValue;

            foreach (int i in array)
                Console.Write(i + " ");
        }
    }
}
