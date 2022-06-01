using System;

namespace Task28PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] jobTitle = new string[0];
            string[] fullName = new string[0];
            int arrayLength;
            string commandLine = "";
            bool isntExit = true;

            while (isntExit)
            {
                Console.WriteLine("1.добавить сотрудника\n2.вывести список сотрудников\n3.удалить сотрудника\n4.найти сотрудника по фамилии\n5.выход\nВведите номер комманды");
                commandLine = Console.ReadLine();

                switch (commandLine)
                {
                    case "1":
                        Console.WriteLine("Введите ФИО: ");
                        string addedFullName = Console.ReadLine();
                        Console.WriteLine("Введите должность: ");
                        string addedJobTitle = Console.ReadLine();
                        AddAccount(ref fullName, ref jobTitle, addedFullName, addedJobTitle);
                        break;
                    case "2":
                        for (int i = 0; i < fullName.Length; i++)
                            Console.WriteLine($"{i+1}.{fullName[i]}-{jobTitle[i]}");

                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Введите индекс удаляемого сотрудника: ");
                        commandLine = Console.ReadLine();
                        arrayLength = fullName.Length;
                        DelleteAccount(ref fullName, ref jobTitle, Convert.ToInt32(commandLine)-1);

                        if (arrayLength == fullName.Length)
                            Console.WriteLine($"Не удалось удалить сотрудника с индексом {commandLine}");
                        else
                            Console.WriteLine($"Сотрудник с индексом {commandLine} был успешно удалён");

                        Console.ReadKey();
                            break;
                    case "4":
                        Console.WriteLine("Введите фамилию: ");
                        commandLine = Console.ReadLine();
                        int[] findedIndexes = FindIndexesBySurname(fullName, commandLine);
                        Console.WriteLine($"Найдено {findedIndexes.Length} сотрудников с фамилией {commandLine}");

                        foreach (int i in findedIndexes)
                            Console.WriteLine($"{i+1}.{fullName[i]}-{jobTitle[i]}");

                        Console.ReadKey();
                        break;
                    case "5":
                        isntExit = false;
                        break;
                }
                Console.Clear();
            }
        }

        static void AddAccount(ref string[] fullName, ref string[] jobTitle, string addedFullName, string addedJobTitle)
        {
            Array.Resize(ref fullName, fullName.Length + 1);
            Array.Resize(ref jobTitle, jobTitle.Length + 1);
            fullName[fullName.Length - 1] = addedFullName;
            jobTitle[jobTitle.Length - 1] = addedJobTitle;
        }

        static void DelleteAccount(ref string[] fullName, ref string[] jobTitle, int index)
        {
                fullName = DeleteArrayElement(fullName, index);
                jobTitle = DeleteArrayElement(jobTitle, index);
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

        static int[] FindIndexesBySurname(string[] fullName, string surname)
        {
            int[] indexes = new int[0];

            for (int i = 0;i < fullName.Length;i++)
            {
                if(fullName[i].Split(' ')[0].ToLower() == surname.ToLower())
                {
                    Array.Resize(ref indexes, indexes.Length + 1);
                    indexes[indexes.Length - 1] = i;
                }    
            }

            return indexes;
        }
    }
}
