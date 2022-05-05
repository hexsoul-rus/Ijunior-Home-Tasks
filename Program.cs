using System;

namespace Task5Replacement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Ivanov";
            string surname = "Andrey";
            string temporary;

            Console.WriteLine("До перестановки - имя: " + name + ", фамилия: " + surname);
            temporary = name;
            name = surname;
            surname = temporary;
            Console.WriteLine("После перестановки - имя: " + name + ", фамилия: " + surname);
        }
    }
}
