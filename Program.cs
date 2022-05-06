using System;

namespace Task11ValueSumm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minRandomValue = - 100;
            int maxRandomValue = 100;
            uint valuesCount = 20;
            int targetValue1 = 3;
            int targetValue2 = 5;
            int valuesSumm = 0;
            int randomValue;
            Random random = new Random();

            for(int i = 0; i < valuesCount; i++)
            {
                randomValue = random.Next(minRandomValue, maxRandomValue);
                Console.Write(randomValue + " ");

                if(randomValue > 0 && (randomValue % targetValue1 == 0 || randomValue % targetValue2 == 0))
                {
                    valuesSumm += randomValue;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Сумма положительных, кратных 3 и 5 чисел = " + valuesSumm);
        }
    }
}
