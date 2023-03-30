using System;
using System.Collections.Generic;

namespace Task34ShopQueue
{
    internal class Program
    {
        static void Main()
        {
            int totalRevenue = 0;
            Queue<int> buyers = new();

            buyers.Enqueue(59);
            buyers.Enqueue(45);
            buyers.Enqueue(155);
            buyers.Enqueue(67);
            buyers.Enqueue(15);

            while (buyers.Count > 0)
            {
                Console.Write("Суммы покупок в очереди клиентов: ");

                foreach (var buyer in buyers)
                {
                    Console.Write(buyer + "  ");
                }

                Console.WriteLine("\nСумма текущей покупки: " + buyers.Peek());
                totalRevenue += buyers.Dequeue();
                Console.WriteLine("Общая выручка: " + totalRevenue);
                Console.WriteLine("Нажмите любую клавишу, чтоб продолжить.");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Все клиенты обслужены. Общая выручка составила:" + totalRevenue);
        }
    }
}
