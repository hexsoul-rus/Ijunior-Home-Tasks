﻿using System;

namespace Task14NameEnter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte verticalBordersCount = 2;
            string nameLine;
            char borderSymbol;
            int borderWidth = 1;

            Console.Write("Введите Имя: ");
            nameLine = Console.ReadLine();
            Console.Write("Введите символ: ");
            borderSymbol = Console.ReadLine()[0];

            for (int i = 0; i <= borderWidth * verticalBordersCount; i++)
            {
                for (int j = 0; j < nameLine.Length + borderWidth * verticalBordersCount; j++)
                {
                    if (i == borderWidth && j >= borderWidth && j < borderWidth + nameLine.Length)
                        Console.Write(nameLine[j - borderWidth]);
                    else
                        Console.Write(borderSymbol);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
