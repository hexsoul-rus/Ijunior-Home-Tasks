using System;

namespace Task25Sort
{
    internal class Program
    {
        static int[] QuickSort(int[] array)
        {
            int pivot = array[0];
            int[] lessThenPivot = new int[0];
            int[] moreThenPivot = new int[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < pivot)
                {
                    Array.Resize(ref lessThenPivot, lessThenPivot.Length + 1);
                    lessThenPivot[lessThenPivot.Length - 1] = array[i];
                }
                else
                {
                    Array.Resize(ref moreThenPivot, moreThenPivot.Length + 1);
                    moreThenPivot[moreThenPivot.Length - 1] = array[i];
                }
            }

            if (lessThenPivot.Length > 1)
                lessThenPivot = QuickSort(lessThenPivot);

            if (moreThenPivot.Length > 1)
                moreThenPivot = QuickSort(moreThenPivot);

            array[lessThenPivot.Length] = pivot;
            Array.Copy(lessThenPivot, array, lessThenPivot.Length);
            Array.Copy(moreThenPivot, 0, array, lessThenPivot.Length + 1, moreThenPivot.Length);
            return array;
        }

        static void Main(string[] args)
        {
            int minRandomValue = 10;
            int maxRandomValue = 100;
            int[] array = new int[30];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandomValue, maxRandomValue);
                Console.Write(array[i] + " ");
            }

            array = QuickSort(array);
            Console.WriteLine();

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
