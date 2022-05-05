using System;

namespace Task4Pictures
{
    internal class CTask4Pictures
    {
        static void Main(string[] args)
        {
            uint picturesCount = 52;
            uint series = 3;

            Console.WriteLine((picturesCount / series) + " полностью заполненных рядов можно вывести.");
            Console.WriteLine((picturesCount % series) + " картинок будет сверх меры.");
        }
    }
}
