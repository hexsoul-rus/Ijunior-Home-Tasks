using System;

namespace Task3Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string zodiac;
            string work;
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
            Console.WriteLine($"Вас зовут {name}, вам {age} лет, вы {zodiac} и работаете {work}.");
            Console.ReadKey();
        }
    }
}
