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
                { "вайб", "Особенное настроение, атмосфера"},
                { "выход", "Хорошего дня!!!" }
            };
            string word;

            do
            {
                Console.WriteLine("Введите слово, чтоб узнать его значение или Выход для завершения.");
                word = Console.ReadLine();
                word = word.ToLower();
                Console.WriteLine(dictionary.ContainsKey(word) ? dictionary[word] : "Нет такого слова в словаре ");
            }
            while(word != "Exit");
        }
    }
}
