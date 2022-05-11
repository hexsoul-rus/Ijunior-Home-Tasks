using System;

namespace Task13Console
{
    internal class Program
    {
        static void HidePasswordLine(string password)
        {
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top - 1);

            for (int i = 0; i < password.Length; i++)
            {
                Console.Write('*');
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            const string exitCommand = "exit";
            string commandLine;
            string passwordLine;
            string password = "";

            Console.WriteLine("Введите комманду (Help - для вывода спика команд):");

            do
            {
                commandLine = Console.ReadLine().ToLower();

                if (password != "" && commandLine != exitCommand) 
                {
                    Console.WriteLine("Введите пароль:");
                    passwordLine = Console.ReadLine();
                    HidePasswordLine(passwordLine);

                    if (passwordLine != password)
                    {
                        Console.WriteLine("Неверный пароль.");
                        Console.Write("Введите правильный пароль или Exit для выхода из консоли:");
                        continue;
                    }
                }

                switch (commandLine)
                {
                    case "help":
                        Console.WriteLine("Help - выводит информацию о командах консоли");
                        Console.WriteLine("Clear - очищает консоль");
                        Console.WriteLine("SetPassword - блокирует консоль паролем");
                        Console.WriteLine("DeletePassword - удаляет блокировку консоли паролем");
                        Console.WriteLine("Exit - выход из консоли");
                        Console.WriteLine("Введите комманду:");
                        break;
                    case "setpassword":
                        Console.WriteLine("Введите новый пароль:");
                        password = Console.ReadLine();
                        HidePasswordLine(password);
                        Console.WriteLine("Пароль успешно установлен.\nВведите команду:");
                        break;
                    case "clear":
                        Console.Clear();
                        Console.WriteLine("Введите комманду:");
                        break;
                    case "deletepassword":

                        if (password == "")
                        {
                            Console.WriteLine("Консоль не заблокирована паролем.");
                        }
                        else
                        {
                            password = "";
                            Console.WriteLine("Блокировка паролем удалена.");    
                        }

                        Console.WriteLine("Введите комманду:");
                        break;
                    case exitCommand:
                        Console.WriteLine("Хорошего дня!");
                        break;
                    default:
                        Console.WriteLine("Неверная команда, введите help для вывода спика команд.");
                        break;
                }
            }
            while (commandLine != exitCommand);
        }
    }
}
