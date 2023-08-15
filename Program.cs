using System;
using System.Collections.Generic;

namespace Task36ExtendedAccounting
{
    class Program
    {
        static void Main()
        {
            const char CommandAddAccount = '1';
            const char CommandPrintAccount = '2';
            const char CommandDeleteAccount = '3';
            const char CommandExit = '4';

            Dictionary<string, string> accounts = new();
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Выберите действие:\n{CommandAddAccount}-Добавить досье\n{CommandPrintAccount}-Вывести досье\n{CommandDeleteAccount}-Удалить досье\n{CommandExit}-Выход");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (key)
                {
                    case CommandAddAccount:
                        AddAccount(accounts);
                        break;

                    case CommandPrintAccount:
                        PrintAccounts(accounts);
                        break;

                    case CommandDeleteAccount:
                        DeleteAccount(accounts);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }

                if (isWorking)
                {
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void AddAccount(Dictionary<string, string> accounts)
        {
            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите должность: ");
            string jobTitle = Console.ReadLine();              

            if (fullName != "" && jobTitle != "") 
            {
                if(accounts.ContainsKey(fullName)) 
                {
                    Console.WriteLine("Досье с таким ФИО уже существует");
                }
                else
                {
                    accounts.Add(fullName, jobTitle);
                }
            }
            else
            {
                Console.WriteLine("Ввод не коректен");
            }
        }

        static void PrintAccounts(Dictionary<string, string> accounts)
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Key} - {account.Value}");
            }
        }

        static void DeleteAccount(Dictionary<string, string> accounts)
        {
            Console.WriteLine("Введите ФИО");
            string fullName = Console.ReadLine();

            if (accounts.ContainsKey(fullName))
            {
                accounts.Remove(fullName);
            }
            else
            {
                Console.WriteLine("Не существует досье с таким ФИО");
            }
        }
    }
}