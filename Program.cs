using System;

namespace Task6Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint crystalsPrice = 25;
            uint gold;
            uint crystals;

            Console.Write("Введите количество вашего золота: ");
            gold = Convert.ToUInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Доро пожаловать в магазин! Чего желаете?");
            Console.Write("Кристаллы (кол-во): ");
            crystals = Convert.ToUInt32(Console.ReadLine());
            gold -= crystals * crystalsPrice;
            Console.Clear();
            Console.WriteLine("Теперь у вас " + crystals + " кристраллов и " + gold + " золота. Спасибо за покупку!");
        }
    }
}
