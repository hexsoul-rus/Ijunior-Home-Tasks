using System;
using System.Collections.Generic;

namespace Task35ExtendedDynamicArray
{
    internal class Program
    {
        static void Main()
        {
            string commandLine;
            int ValuesSum;
            bool isExit = false;
            List<int> Values = new();

            while (isExit == false)
            {
                Console.WriteLine("Введите целое число, чтобы добавить его в список; sum - вычисления суммы элементов списка; exit - выход.");
                commandLine = Console.ReadLine().ToLower();
                Console.Clear();

                if (commandLine == "sum")
                {
                    ValuesSum = 0;

                    foreach (int value in Values)
                    {
                        ValuesSum += value;
                    }

                    Console.WriteLine("Сумма введённых чисел = " + ValuesSum);
                }
                else if (commandLine == "exit")
                    isExit = true;
                else if (int.TryParse(commandLine, out int value))
                    Values.Add(value);
            } 
        }
    }
}