using System;

namespace Task20RowsAndColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minRandomValue = 1;
            int maxRandomValue = 10;
            int rowNumber = 2;
            int columnNumber = 1;
            int rowSumm = 0;
            int columnMult= 1;

            int[,] array = new int [5, 5];
            Random random = new Random();
            rowNumber--;
            columnNumber--;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minRandomValue, maxRandomValue);
                    Console.Write(array[i,j]+" ");
                }

                Console.WriteLine();
            }

            for (int i = 0;i < array.GetLength(1); i++)
            {
                rowSumm += array[rowNumber,i];
            }

            rowNumber++;
            Console.WriteLine("Сумма элементов " + rowNumber + " строки = " + rowSumm);

            for (int j = 0;j < array.GetLength(0); j++)
            {
                columnMult *= array[j,columnNumber];
            }

            columnNumber++;
            Console.WriteLine("Произведение элементов " + columnNumber + " столбца = " + columnMult);
        }
    }
}
