using System;
using System.Collections.Generic;
using System.Linq;

namespace Task40PlayersDataBase
{
    internal class Program
    {
        static void Main()
        {
            ConsoleControl consoleControl = new ConsoleControl ();
            consoleControl.Run();
        }
    }

    public class Player
    {
        public string Name {get; private set;}
        public bool IsBanned {get; private set;}
        public int Id 
        { 
            get 
            { 
                return _id; 
            } 
        }

        private int _id;

        public Player(int id, string name) 
        { 
            Name = name;
            IsBanned = false;
            _id = id;
        }

        public void Ban()
        {
            IsBanned=true;
        }

        public void Unban()
        {
            IsBanned=false;
        }
    }

    public class Database
    {
        public List<Player> Players { get; private set; } = new List<Player>();
        private int _lastId = 0;

        public void Add(string name)
        {
            _lastId++;
            Player player = new Player(_lastId, name);
            Players.Add(player);
        }

        public void Remove(Player player)
        {
            Players.Remove(player);
        }

        public List<Player> GetAll()
        {
            List<Player> allPlayers = new List<Player>();

            foreach (Player player in Players)
            {
                allPlayers.Add(player);
            }

            return allPlayers;
        }

        public Player Find(int id)
        {
            return Players.FirstOrDefault(player => player.Id == id);
        }
    }

class ConsoleControl
    {
        public void Run()
        {
            const char CommandAddPlayer = '1';
            const char CommandBanPlayer = '2';
            const char CommandUnbanPlayer = '3';
            const char CommandDeletePlayer = '4';
            const char CommandShowPlayer = '5';
            const char CommandExit = '6';

            Database players = new Database();
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
                        TryGetPlayer(players)?.Ban();
                        break;

                    case CommandUnbanPlayer:
                        TryGetPlayer(players)?.Unban();
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

        private Player TryGetPlayer(Database players)
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
            Player player = TryGetPlayer(players);

            if (player != null)
            {
                players.Remove(player);
            }
        }
    }
}
