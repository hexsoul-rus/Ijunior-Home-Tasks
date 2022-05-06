using System;

namespace Task9ExitControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string commandLine = "";
            string exitCommand = "exit";

            while (commandLine != exitCommand)
            {
                Console.WriteLine("У попа была собака,");
                Console.WriteLine("Он ее любил.");
                Console.WriteLine("Она съела кусок мяса,");
                Console.WriteLine("Он ее убил!");
                Console.WriteLine("В землю закопал,");
                Console.WriteLine("Надпись написал, что:\n");
                Console.Write("Для выхода введите " + exitCommand + " или нажмите Enter, чтобы продолжить: ");
                commandLine = Console.ReadLine();
                Console.WriteLine();
            }
        }
    }
}
