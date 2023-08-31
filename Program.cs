using System;
using System.Collections.Generic;
using System.Linq;

namespace Task40PlayersDataBase
{
    internal class Program
    {
        static void Main()
        {
            ConsoleControl consoleControl = new ();
            consoleControl.Run();
        }
    }

    public class Player
    {
        public readonly int Id;
        public string Name {get; private set;}
        public bool IsBanned {get; private set;}

        public Player(int id, string name) 
        { 
            Name = name;
            IsBanned = false;
            Id = id;
        }

        public void Ban()
        {
            IsBanned=true;
        }

        public void Unbun()
        {
            IsBanned=false;
        }

        internal Player Clone()
        {
            Player clonedPlayer = new(Id, Name);
            clonedPlayer.IsBanned = IsBanned;
            return clonedPlayer;
        }
    }

    public class Database
    {
        private int _lastId = 0;
        private readonly List<Player> Players = new ();

        public void Add(string name)
        {
            _lastId++;
            Player player = new(_lastId, name);
            Players.Add(player);
        }

        public void Remove(Player player)
        {
            Players.Remove(player);
        }

        public List<Player> GetAll()
        {
            List<Player> players = new();

            foreach (Player player in Players)
            {
                Player clonedPlayer = (Player) player.Clone();
                players.Add(clonedPlayer);
            }

            return players;
        }

        public Player Find(int id)
        {
            return Players.FirstOrDefault(player => player.Id == id);
        }
    }

class ConsoleControl
    {
        private Player GetPlayer(Database players)
        {
            Console.WriteLine("Введите id: ");
            Int32.TryParse(Console.ReadLine(), out int id);
            Player player = players.Find(id);

            if (player == null)
            {
                Console.WriteLine("Введён некорректный id");
            }

            return player;
        }

        private void ShowPlayersInfo(Database players)
        {
            List<Player> allPlayers = players.GetAll();

            foreach (Player player in allPlayers)
            {
                Console.WriteLine($"{player.Id} - name:{player.Name} ban:{player.IsBanned}");
            }
        }

        private void AddPlayer(Database players)
        {
            Console.WriteLine("Введите имя игрока");
            string name = Console.ReadLine();
            players.Add(name);
        }

        private void RemovePlayer(Database players)
        {
            Player player = GetPlayer(players);

            if (player != null)
            {
                players.Remove(player);
            }
        }

        public void Run()
        {
            const char CommandAddPlayer = '1';
            const char CommandBanPlayer = '2';
            const char CommandUnbanPlayer = '3';
            const char CommandDeletePlayer = '4';
            const char CommandShowPlayer = '5';
            const char CommandExit = '6';
            Database players = new();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine($"выберите действие:\n{CommandAddPlayer}-добавить игрока\n{CommandBanPlayer}-забанить игрока\n" +
                    $"{CommandUnbanPlayer}-разбанить игрока\n{CommandDeletePlayer}-удалить игрока\n{CommandShowPlayer}-вывести всех игроков\n{CommandExit}-выход");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (key)
                {
                    case CommandAddPlayer:
                        AddPlayer(players);
                        break;

                    case CommandBanPlayer:
                        GetPlayer(players)?.Ban();
                        break;

                    case CommandUnbanPlayer:
                        GetPlayer(players)?.Unbun();
                        break;

                    case CommandDeletePlayer:
                        RemovePlayer(players);
                        break;

                    case CommandShowPlayer:
                        ShowPlayersInfo(players);
                        break;

                    case CommandExit:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Неверно выбрано действие");
                        break;
                }

                Console.WriteLine("для продолжения нажмите любую кнопку");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
