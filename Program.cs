using System;

namespace Task30ReadInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value = ReadIntValue();
            Console.WriteLine($"Введённое целочисленное значение {value}");
        }

        private static int ReadIntValue()
        {
            string enteredValue;
            int parsedValue;
            bool isParsed;

            do
            {
                Console.Write("Введите целочисленное значение:");
                enteredValue = Console.ReadLine();
                isParsed = int.TryParse(enteredValue, out parsedValue);

                if (isParsed == false)
                    Console.Write("Вводе не является целочисленным значением. ");
            }
            while (isParsed == false);

            return parsedValue;
        }
    }
}
