using System;
using System.Collections.Generic;

namespace Task36ExtendedAccounting
{
    public class Account
    {
        public string LastName;
        public string FirstName;
        public string FatherName;
        public int JobTitleIndex;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Account> accounts = new Dictionary<int, Account>();
            List<string> jobTitles = new List<string>();
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Выберите действие:\n1-Добавить досье\n2-Вывести досье\n3-Удалить досье\n4-Выход");
                char Key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (Key)
                {
                    case '1':
                        AddAccount(accounts, jobTitles);
                        break;
                    case '2':
                        PrintAccounts(accounts, jobTitles);
                        break;
                    case '3':
                        DeleteAccount(accounts);
                        break;
                    case '4':
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

        static void AddAccount(Dictionary<int, Account> accounts, List<string> jobTitles)
        {
            int accountIndex = GetAccountIndex(accounts, out bool isCorrect, out bool isExist);
            string jobTitle;
            int jobTitleIndex;

            if (isCorrect)
            {
                if (isExist == false)
                {
                    Account NewAccount = new Account();
                    Console.Write("Введите Фамилию: ");
                    NewAccount.LastName = Console.ReadLine();
                    Console.Write("Введите Имя: ");
                    NewAccount.FirstName = Console.ReadLine();
                    Console.Write("Введите Отчество: ");
                    NewAccount.FatherName = Console.ReadLine();
                    Console.Write("Введите должность: ");
                    jobTitle = Console.ReadLine();
                    jobTitleIndex = jobTitles.IndexOf(jobTitle);

                    if(jobTitleIndex == -1)
                    {
                        NewAccount.JobTitleIndex = jobTitles.Count;
                        jobTitles.Add(jobTitle);                
                    }
                    else
                    {
                        NewAccount.JobTitleIndex = jobTitleIndex;
                    }
                                        
                    accounts.Add(accountIndex, NewAccount);
                }
                else
                {
                    Console.WriteLine("Досье с таким номером уже существует");
                }
            }
        }

        static void PrintAccounts(Dictionary<int, Account> accounts, List<string> jobTitles)
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Key} {account.Value.LastName} {account.Value.FirstName} {account.Value.FatherName} - {jobTitles[account.Value.JobTitleIndex]}");
            }
        }

        static void DeleteAccount(Dictionary<int, Account> accounts)
        {
            int accountIndex = GetAccountIndex(accounts, out bool isCorrect, out bool isExist);

            if (isExist)
            {
                accounts.Remove(accountIndex);
            }
            else
            {
                Console.WriteLine("Не существует досье с таким номером");
            }
        }

        static int GetAccountIndex(Dictionary<int, Account> accounts, out bool isCorrect, out bool isExist)
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