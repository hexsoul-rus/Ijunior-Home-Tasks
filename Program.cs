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
            bool isConverted;

            do
            {
                isConverted = false;
                commandLine = "";
                Console.WriteLine($"Текущий баланс USD:{usdBalance} EUR:{eurBalance} GBP:{gbpBalance}");
                Console.WriteLine("Что будем конвертировать?\n1.USD\n2.EUR\n3.GBP");
                commandLine += Console.ReadLine();
                Console.WriteLine("Во что будем конвертировать?\n1.USD\n2.EUR\n3.GBP");
                commandLine += Console.ReadLine();
                Console.WriteLine("Сколько будем конвертировать?");
                convertionValue = Convert.ToSingle(Console.ReadLine());

                if (convertionValue < 0)
                    commandLine = "";

                switch (commandLine)
                {
                    case "12":
                        if (convertionValue <= usdBalance)
                        {
                            usdBalance -= convertionValue;
                            eurBalance += convertionValue * usdToEur;
                            isConverted = true;
                        }
                        break;
                    case "13":
                        if (convertionValue <= usdBalance)
                        {
                            usdBalance -= convertionValue;
                            gbpBalance += convertionValue * usdToGbp;
                            isConverted = true;
                        }
                        break;
                    case "21":
                        if (convertionValue <= eurBalance)
                        {
                            eurBalance -= convertionValue;
                            usdBalance += convertionValue * eurToUsd;
                            isConverted = true;
                        }
                        break;
                    case "23":
                        if (convertionValue <= eurBalance)
                        {
                            eurBalance -= convertionValue;
                            gbpBalance += convertionValue * eurToGbp;
                            isConverted = true;
                        }
                        break;
                    case "31":
                        if (convertionValue <= gbpBalance)
                        {
                            gbpBalance -= convertionValue;
                            usdBalance += convertionValue * gbpToUsd;
                            isConverted = true;
                        }
                        break;
                    case "32":
                        if (convertionValue <= gbpBalance)
                        {
                            gbpBalance -= convertionValue;
                            eurBalance += convertionValue * gbpToEur;
                            isConverted = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }

                if (isConverted)
                    Console.WriteLine($"Баланс после конвертации USD:{usdBalance} EUR:{eurBalance} GBP:{gbpBalance}");
                else
                    Console.WriteLine("Недостаточно средств.");

                Console.Write("Введите " + exitCommand + " для выхода: ");
                commandLine = Console.ReadLine();
                Console.Clear();
            }
            while (commandLine != exitCommand);
        }
    }
}
