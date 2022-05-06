using System;

namespace Task8Cycles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message;
            uint repetitionsCount;

            Console.Write("Введите сообщение: ");
            message = Console.ReadLine();
            Console.Write("Количество повторов: ");
            repetitionsCount = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine();   

            for (int i = 0; i < repetitionsCount; i++)
            {
                Console.WriteLine(message);
            }
        }
    }
}
