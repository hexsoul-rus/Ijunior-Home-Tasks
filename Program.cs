using System;

namespace Task29UIElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fillPercent = 30;
            int leftPosition = 5;
            int topPosition = 2;
            int barLength = 20;
            ConsoleColor color = ConsoleColor.Blue;

            DrawUIBar(fillPercent, color, leftPosition, topPosition, barLength, ' ');
            Console.ReadLine();
        }

        static void DrawUIBar(int fillPercent, ConsoleColor fillColor, int leftPosition, int topPosition, int barLength, char fillSymbol = '#', char emptySpaceSymbol = '-')
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            int fill = Convert.ToInt32(barLength / 100f * fillPercent);

            Console.SetCursorPosition(leftPosition, topPosition);
            Console.Write("[");
            Console.BackgroundColor = fillColor;

            for (int i = 0; i < fill; i++)
            {
                Console.Write(fillSymbol);
            }

            Console.BackgroundColor = defaultColor;

            for (int i = fill; i < barLength; ++i)
            {
                Console.Write(emptySpaceSymbol);
            }

            Console.Write("]");
        }
    }
}
