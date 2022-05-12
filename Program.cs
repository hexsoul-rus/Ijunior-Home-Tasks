using System;

namespace Task18Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lineOfParentheses;
            int entryDepth=0;
            int maxEntryDepth=0;
            bool isCorrect=true;

            Console.WriteLine("Введите скобочное выражение");
            lineOfParentheses = Console.ReadLine();

            for (int i = 0; i < lineOfParentheses.Length; i++)
            {
                if (lineOfParentheses[i] == '(')
                {
                    entryDepth++;

                    if(entryDepth > maxEntryDepth)
                        maxEntryDepth = entryDepth;
                }
                else if (lineOfParentheses[i] == ')')
                {
                    entryDepth--;
                }

                if (entryDepth < 0)
                    isCorrect = false;
            }

            if (isCorrect && entryDepth == 0)
                Console.WriteLine("Скобочное выражение является корректным, максимальная глубина вложенности = " + maxEntryDepth);
            else
                Console.WriteLine("Скобочное выражение не корректно.");
            Console.ReadLine();
        }
    }
}
