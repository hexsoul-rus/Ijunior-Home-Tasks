using System;

namespace Task3Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name, zodiac, work, yearSuffix;
            byte age;

            Console.WriteLine("Как вас зовут?");
            name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Какой ваш знак зодиака?");
            zodiac = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Сколько вам лет?");
            age = Convert.ToByte(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Где вы работаете?");
            work = Console.ReadLine();
            Console.Clear();

            if (age % 10 > 4 || age % 10 == 0 || age < 20 && age > 10)
                yearSuffix = "лет";
            else if (age % 10 > 1)
                yearSuffix = "года";
            else
                yearSuffix = "год";

            Console.WriteLine($"Вас зовут {name}, вам {age} {yearSuffix}, вы {zodiac} и работаете {work}.");
            Console.ReadKey();
        }
    }
}
