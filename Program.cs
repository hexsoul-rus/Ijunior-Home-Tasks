using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Task40PlayersDataBase
{
    internal class Program
    {
        static void Main()
        {
            ConsoleControl consoleControl = new ();
            consoleControl.Command();
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

        public Player(int id, string name, bool isBanned)
        {
            Name = name;
            IsBanned = isBanned;
            Id = id;
        }

        internal Player Clone()
        {
            return new Player(Id,Name,IsBanned);
        }

        public void Ban()
        {
            IsBanned=true;
        }

        public void Unbun()
        {
            IsBanned=false;
        }
    }

    public class Database
    {
        public readonly List<Player> Players = new ();
        private int _lastId = 0;

        public void AddNewPlayer()
        {
            Console.WriteLine("Введите имя игрока");
            string name = Console.ReadLine();
            _lastId++;
            Player player = new(_lastId, name);
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public List<Player> GetPlayers()
        {
            List<Player> players = new();

            foreach (Player player in Players)
            {
                Player clonedPlayer = (Player) player.Clone();
                players.Add(clonedPlayer);
            }

            return players;
        }
    }

class ConsoleControl
    {
        private Player GetPlayer(Database playersData)
        {
            Console.WriteLine("Введите id: ");
            Int32.TryParse(Console.ReadLine(), out int id);
            return playersData.Players.FirstOrDefault(player => player.Id == id);
        }

        private void ShowPlayersInfo(Database playersData)
        {
            var players = playersData.GetPlayers();

            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Id} - name:{player.Name} ban:{player.IsBanned}");
            }
        }

        public void Command()
        {
            const char CommandAddPlayer = '1';
            const char CommandBanPlayer = '2';
            const char CommandUnbanPlayer = '3';
            const char CommandDeletePlayer = '4';
            const char CommandShowPlayer = '5';
            const char CommandExit = '6';
            Database playersData = new();
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
                        playersData.AddNewPlayer();
                        break;

                    case CommandBanPlayer:
                        GetPlayer(playersData)?.Ban();
                        break;

                    case CommandUnbanPlayer:
                        GetPlayer(playersData)?.Unbun();
                        break;

                    case CommandDeletePlayer:
                        Player player = GetPlayer(playersData);
                        playersData.RemovePlayer(player);
                        break;

                    case CommandShowPlayer:
                        ShowPlayersInfo(playersData);
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
