using System;
using System.Collections.Generic;

namespace Task33Dictionary
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, string> dictionary = new()
            {
                { "кринж", "Нечто жуткое, отвратительное."},
                { "рофл", "ROFL [аббревиатура] ... кататься на полу от смеха"},
                { "вайб", "Особенное настроение, атмосфера"}
            };
            string word;
            bool isExit = false;

            do
            {
                Console.WriteLine("Введите слово, чтоб узнать его значение или Выход для завершения.");
                word = Console.ReadLine().ToLower();

                if (word == "выход")
                    isExit = true;
                else if (dictionary.ContainsKey(word))
                    Console.WriteLine(dictionary[word]);
                else
                    Console.WriteLine("Нет такого слова в словаре.");
            }
            while(isExit == false);
        }
    }
}
