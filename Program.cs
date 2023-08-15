using System;
using System.Collections.Generic;

namespace Task36ExtendedAccounting
{
    class Program
    {
        static void Main(string[] args)
        {
            const char CommandAdd = '1';
            const char CommandPrint = '2';
            const char CommandDelete = '3';
            const char CommandExit = '4';
            Dictionary<int, string> fullNames = new Dictionary<int, string>();
            Dictionary<int, string> jobTitles = new Dictionary<int, string>();
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Выберите действие:\n{CommandAdd}-Добавить досье\n{CommandPrint}-Вывести досье\n{CommandDelete}-Удалить досье\n{CommandExit}-Выход");
                char Key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (Key)
                {
                    case CommandAdd:
                        AddAccount(fullNames, jobTitles);
                        break;

                    case CommandPrint:
                        PrintAccounts(fullNames, jobTitles);
                        break;

                    case CommandDelete:
                        DeleteAccount(fullNames, jobTitles);
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

        static void AddAccount(Dictionary<int, string> fullNames, Dictionary<int, string> jobTitles)
        {
            int accountIndex = GetAccountIndex(fullNames, out bool isCorrect, out bool isExist);
            string fullName;
            string jobTitle;

            if (isCorrect)
            {
                if (isExist == false)
                {
                    Console.Write("Введите ФИО: ");
                    fullName = Console.ReadLine();
                    Console.Write("Введите должность: ");
                    jobTitle = Console.ReadLine();              
                    fullNames.Add(accountIndex, fullName);
                    jobTitles.Add(accountIndex, jobTitle);
                }
                else
                {
                    Console.WriteLine("Досье с таким номером уже существует");
                }
            }
        }

        static void PrintAccounts(Dictionary<int, string> fullNames, Dictionary<int, string> jobTitles)
        {
            foreach (var fullName in fullNames)
            {
                Console.WriteLine($"{fullName.Key} {fullName.Value} - {jobTitles[fullName.Key]}");
            }
        }

        static void DeleteAccount(Dictionary<int, string> fullNames, Dictionary<int, string> jobTitles)
        {
            int accountIndex = GetAccountIndex(fullNames, out bool isCorrect, out bool isExist);

            if (isExist)
            {
                fullNames.Remove(accountIndex);
                jobTitles.Remove(accountIndex);
            }
            else
            {
                Console.WriteLine("Не существует досье с таким номером");
            }
        }

        static int GetAccountIndex(Dictionary<int, string> accounts, out bool isCorrect, out bool isExist)
        {
            int accountIndex;
            Console.Write("Введите номер досье: ");
            isCorrect = Int32.TryParse(Console.ReadLine(), out accountIndex);

            if (isCorrect)
            {
                isExist = accounts.TryGetValue(accountIndex, out var account);
                return accountIndex;
            }
            else
            {
                Console.WriteLine("Неверно указан номер досье");
                isExist = false;
                return 0;
            }
        }
    }
}