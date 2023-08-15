using System;

namespace Task28PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] jobTitles = new string[0];
            string[] fullNames = new string[0];
            string commandLine = "";
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("1.добавить сотрудника\n2.вывести список сотрудников\n3.удалить сотрудника\n4.найти сотрудника по фамилии\n5.выход\nВведите номер комманды");
                commandLine = Console.ReadLine();

                switch (commandLine)
                {
                    case "1":
                        AddAccount(ref fullNames, ref jobTitles);
                        break;
                    case "2":
                        for (int i = 0; i < fullNames.Length; i++)
                            Console.WriteLine($"{i + 1}.{fullNames[i]} - {jobTitles[i]}");
                        break;
                    case "3":
                        DelleteAccount(ref fullNames, ref jobTitles);
                        break;
                    case "4":
                        FindAccounts(fullNames, jobTitles);
                        break;
                    case "5":
                        isWork = false;
                        break;
                }

                if (isWork)
                {
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void AddAccount(ref string[] fullName, ref string[] jobTitle)
        {
            Console.WriteLine("Введите ФИО: ");
            string addedFullName = Console.ReadLine();
            Console.WriteLine("Введите должность: ");
            string addedJobTitle = Console.ReadLine();
            fullName=AddArrayElement(fullName, addedFullName);
            jobTitle=AddArrayElement(jobTitle, addedJobTitle);
            Console.WriteLine("Сотрудник добавлен");
        }

        static void DelleteAccount(ref string[] fullNames, ref string[] jobTitles)
        {
            int arrayLength = fullNames.Length;
            int index;

            Console.WriteLine("Введите индекс удаляемого сотрудника: ");
            index = Convert.ToInt32(Console.ReadLine());
            fullNames = DeleteArrayElement(fullNames, index-1);
            jobTitles = DeleteArrayElement(jobTitles, index-1);

            if (arrayLength == fullNames.Length)
                Console.WriteLine($"Не удалось удалить сотрудника с индексом {index}");
            else
                Console.WriteLine($"Сотрудник с индексом {index} был успешно удалён");
        }

        static void FindAccounts(string[] fullNames, string[] jobTitles)
        {
            string surname;

            Console.WriteLine("Введите фамилию: ");
            surname = Console.ReadLine();

            for (int i = 0;i < fullNames.Length;i++)
            {
                if(fullNames[i].Split(' ')[0].ToLower() == surname.ToLower())
                    Console.WriteLine($"{i+1} {fullNames[i]} - {jobTitles[i]}");    
            }
        }

        static string[] AddArrayElement(string[] array, string element)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                tempArray[i] = array[i];

            tempArray[array.Length] = element;
            return tempArray;
        }

        private static string[] DeleteArrayElement(string[] array, int index)
        {
            if (index >= 0 && index < array.Length)
            {
                string[] tempArray = new string[array.Length - 1];

                for (int i = 0; i < tempArray.Length; i++)
                    if (i < index)
                        tempArray[i] = array[i];
                    else
                        tempArray[i] = array[i + 1];

                array = tempArray;
            }

            return array;
        }
    }
}
