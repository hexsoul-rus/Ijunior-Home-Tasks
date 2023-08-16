using System;

namespace Task38PlayerClass
{
    public class Player
    {
        private readonly string _name = "player";
        private int _health = 100;

        public Player(string name, int health)
        { 
            _name = name;

            if (health > 0)
                _health = health;
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine($"Имя игрока: {_name}, колличество жизней: {_health}");
        }
    }

    internal class Program
    {
        static void Main()
        {
            Player player = new("Vasya", 150);
            player.ShowPlayerInfo();
        }
    }
}
