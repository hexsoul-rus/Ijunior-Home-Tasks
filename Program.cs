using System;

namespace Task11ValueSumm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minRandomValue = 0;
            int maxRandomValue = 100;
            int targetValue1 = 3;
            int targetValue2 = 5;
            int valuesSumm = 0;

            Random random = new Random();
            int randomValue = random.Next(minRandomValue, maxRandomValue);

            for (int i = 0; i < randomValue; i++)
            {
                if(i % targetValue1 == 0 || i % targetValue2 == 0)
                {
                    valuesSumm += i;
                }
            }

            Console.WriteLine("Сумма всех положительных чисел меньше или равных " + randomValue + ", кратных 3 и 5 = " + valuesSumm);
        }
    }
}
