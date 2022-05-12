using System;

namespace Task17Rate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minRandomValue = 4;
            int maxRandomValue = 100;
            int baseValue = 2;
            int rateCount = 1;
            int rateValue = baseValue;
            int randomValue;

            Random random = new Random();
            randomValue = random.Next(minRandomValue,maxRandomValue);

            while(rateValue <= randomValue)
            {
                rateCount ++;
                rateValue *= baseValue;
            }

            Console.WriteLine($"{rateCount} - минимальная степень двойки равная {rateValue}, превосходящая число {randomValue}");
        }
    }
}
