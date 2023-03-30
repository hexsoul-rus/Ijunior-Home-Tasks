using System;
using System.Collections.Generic;

namespace Task34ShopQueue
{
    internal class Program
    {
        static void Main()
        {
            int totalRevenue = 0;
            Queue<int> buyersSums = new();

            buyersSums.Enqueue(59);
            buyersSums.Enqueue(45);
            buyersSums.Enqueue(155);
            buyersSums.Enqueue(67);
            buyersSums.Enqueue(15);

            while (buyersSums.Count > 0)
            {
                Console.Write("Суммы покупок в очереди клиентов: ");

                foreach (var item in buyersSums)
                {
                    Console.Write(item + "  ");
                }

                Console.WriteLine("\nСумма текущей покупки: " + buyersSums.Peek());
                totalRevenue += buyersSums.Dequeue();
                Console.WriteLine("Общая выручка: " + totalRevenue);
                Console.WriteLine("Нажмите любую клавишу, чтоб продолжить.");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Все клиенты обслужены. Общая выручка составила:" + totalRevenue);
        }
    }
}
