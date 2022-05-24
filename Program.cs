using System;

namespace Task23DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string commandLine;
            int arrayValuesSum;
            int[] array = new int[0];

            do
            {
                Console.WriteLine("Введите целое число, чтобы добавить его в массив; sum - вычисления суммы элементов массива; exit - выход.");
                commandLine = Console.ReadLine();
                Console.Clear();

                if (commandLine.ToLower() == "sum")
                {
                    arrayValuesSum = 0;

                    for (int i = 0; i < array.Length; i++)
                    {
                        arrayValuesSum += array[i];
                    }

                    Console.WriteLine("Сумма введённых чисел = " + arrayValuesSum);
                }
                else if (int.TryParse(commandLine, out int value))
                {
                    int[] tempArray = new int[array.Length + 1];

                    for (int i = 0; i < array.Length; i++)
                    {
                        tempArray[i] = array[i];
                    }

                    array = tempArray;
                    array[array.Length - 1] = value;
                }
            }
            while (commandLine.ToLower() != "exit");
        }
    }
}
