using System;
using System.Collections.Generic;

namespace Task36ExtendedAccounting
{
    public struct Account
    {
        public string SecondName;
        public string FirstName;
        public string Work;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Account> accounts = new Dictionary<int, Account>();
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Введите номер действия (1-Добавить досье, 2-Вывести досье, 3-Удалить досье, 4-Выход");
                char Key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (Key)
                {
                    case '1':
                        AddAccount(accounts);
                        break;
                    case '2':
                        PrintAccounts(accounts);
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

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddAccount (Dictionary<int, Account> accounts)
        {
            int index = GetAccountIndex(accounts, out bool isCorrect, out bool isExist);

            if (isCorrect)
            {
                if (isExist == false)
                {
                    Account NewAccount = new Account();
                    Console.Write("Введите Имя: ");
                    NewAccount.FirstName = Console.ReadLine();
                    Console.Write("Введите Фамилию: ");
                    NewAccount.SecondName = Console.ReadLine();
                    Console.Write("Введите должность: ");
                    NewAccount.Work = Console.ReadLine();
                    accounts.Add(index, NewAccount);
                }
                else
                {
                    Console.WriteLine("Досье с таким номером уже существует");
                }
            }
        }

        static void PrintAccounts(Dictionary<int, Account> accounts)
        {
            foreach (var account in accounts)
            {
                Console.WriteLine(account.Key + " " + account.Value.FirstName + " " + account.Value.SecondName + " - " + account.Value.Work);
            }
        }

        static void DeleteAccount(Dictionary<int, Account> accounts)
        {
            int index = GetAccountIndex(accounts, out bool isCorrect, out bool isExist);

            if(isExist)
            {
                accounts.Remove(index);
            }
            else
            {
                Console.WriteLine("Не существует досье с таким номером");
            }
        }

        static int GetAccountIndex(Dictionary<int, Account> accounts, out bool isCorrect, out bool isExist)
        {
            int index;
            Console.Write("Введите номер досье: ");
            isCorrect = Int32.TryParse(Console.ReadLine(), out index);

            if (isCorrect)
            {
                isExist = accounts.TryGetValue(index, out var account);
                return index;
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
