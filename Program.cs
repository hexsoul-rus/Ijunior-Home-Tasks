using System;
using System.Collections.Generic;

namespace Task35ExtendedDynamicArray
{
    internal class Program
    {
        static void Main()
        {
            bool isRunning = true;
            string commandLine;
            string sumCommand = "sum";
            string exitCommand = "exit";
            List<int> values = new();

            while (isRunning)
            {
                Console.WriteLine($"Введите целое число, чтобы добавить его в список; {sumCommand} - вычисления суммы элементов списка; {exitCommand} - выход."); ;
                commandLine = Console.ReadLine().ToLower();
                Console.Clear();

                if (commandLine == sumCommand)
                    ShowSum(values);
                else if (commandLine == exitCommand)
                    isRunning = false;
                else if (int.TryParse(commandLine, out int value))
                    values.Add(value);
            } 
        }

        static void ShowSum(List<int> values)
        {
            int valuesSum = 0;

            foreach (int value in values)
                valuesSum += value;

            Console.WriteLine("Сумма введённых чисел = " + valuesSum);
        }
    }
}