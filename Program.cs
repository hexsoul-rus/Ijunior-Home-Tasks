using System;

namespace Task10Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint valueStep = 7;
            uint minValue = 5;
            uint maxValue = 96;

            for (uint i = minValue; i <= maxValue; i += valueStep)
            {
                Console.Write(i + " ");
            }
        }
    }
}
