using System;

namespace Task15Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect = false;
            int attemptsCount = 3;
            string password = "qwerty";
            string passwordLine;

            while (isCorrect == false && attemptsCount-- > 0)
            {
                Console.Write("Введите пароль: ");
                passwordLine = Console.ReadLine();

                if (passwordLine == password)
                    isCorrect = true;
                else
                    Console.WriteLine("Неверный пароль! Осталось " + attemptsCount + " попыток.");
            }

            if (isCorrect)
                Console.WriteLine("Это то самое секретное сообщение!");
            else
                Console.WriteLine("Слишком много попыток ввода!");

            Console.ReadLine();
        }
    }
}
