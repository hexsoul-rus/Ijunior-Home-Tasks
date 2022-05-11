using System;

namespace Task12Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float usdToEur = 0.95f;
            float usdToGbp = 0.81f;
            float eurToGbp = 0.85f;
            float eurToUsd = 1.06f;
            float gbpToUsd = 1.23f;
            float gbpToEur = 1.17f;
            float usdBalance = 500f;
            float gbpBalance = 100f;
            float eurBalance = 350f;
            float convertionValue;
            string commandLine;
            string exitCommand = "exit";

            do
            {
                commandLine = "";
                Console.WriteLine($"Текущий баланс USD:{usdBalance} EUR:{eurBalance} GBP:{gbpBalance}");
                Console.WriteLine("Что будем конвертировать?\n1.USD\n2.EUR\n3.GBP");
                commandLine += Console.ReadLine();
                Console.WriteLine("Во что будем конвертировать?\n1.USD\n2.EUR\n3.GBP");
                commandLine += Console.ReadLine();
                Console.WriteLine("Сколько будем конвертировать?");
                convertionValue = Convert.ToSingle(Console.ReadLine());

                switch (commandLine)
                {
                    case "12":
                        usdBalance -= convertionValue;
                        eurBalance += convertionValue * usdToEur;
                        break;
                    case "13":
                        usdBalance -= convertionValue;
                        gbpBalance += convertionValue + usdToGbp;
                        break;
                    case "21":
                        eurBalance -= convertionValue;
                        usdBalance += convertionValue * eurToUsd;
                        break;
                    case "23":
                        eurBalance -= convertionValue;
                        gbpBalance += convertionValue + eurToGbp;
                        break;
                    case "31":
                        gbpBalance -= convertionValue;
                        usdBalance += convertionValue * gbpToUsd;
                        break;
                    case "32":
                        gbpBalance -= convertionValue;
                        eurBalance += convertionValue + gbpToEur;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }

                Console.WriteLine($"Баланс после конвертации USD:{usdBalance} EUR:{eurBalance} GBP:{gbpBalance}");
                Console.Write("Введите " + exitCommand + " для выхода: ");
                commandLine = Console.ReadLine();
                Console.Clear();
            }
            while (commandLine != exitCommand);
        }
    }
}
