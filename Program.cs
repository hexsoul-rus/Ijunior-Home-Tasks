using System;
using System.Collections.Generic;

namespace Task35ExtendedDynamicArray
{
    internal class Program
    {
        static void Main()
        {
            bool isExit = false;
            string commandLine;
            string sumCommand = "sum";
            string exitCommand = "exit";
            List<int> values = new();

            while (isExit == false)
            {
                Console.WriteLine("Введите целое число, чтобы добавить его в список; sum - вычисления суммы элементов списка; exit - выход.");
                commandLine = Console.ReadLine().ToLower();
                Console.Clear();

                if (commandLine == sumCommand)
                    WriteSumToConsole(values);
                else if (commandLine == exitCommand)
                    isExit = true;
                else if (int.TryParse(commandLine, out int value))
                    values.Add(value);
            } 
        }

        static void WriteSumToConsole(List<int> values)
        {
            int valuesSum = 0;

            foreach (int value in values)
                valuesSum += value;

            Console.WriteLine("Сумма введённых чисел = " + valuesSum);
        }
    }
}