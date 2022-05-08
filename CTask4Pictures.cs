using System;

namespace Task4Pictures
{
    internal class CTask4Pictures
    {
        static void Main(string[] args)
        {
            uint picturesCount = 52;
            uint series = 3;
            uint seriesCount;
            uint extraPictures;

            seriesCount = picturesCount / series;
            extraPictures = picturesCount % series;
            Console.WriteLine(seriesCount + " полностью заполненных рядов можно вывести.");
            Console.WriteLine(extraPictures + " картинок будет сверх меры.");
        }
    }
}
