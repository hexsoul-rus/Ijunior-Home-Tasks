using System;
using System.Collections.Generic;
using System.Linq;

namespace Task40PlayersDataBase
{
    public struct PlayerData
    {
        public string Name;
        public bool IsBanned;
        public PlayerData(string name) 
        { 
            Name = name;
            IsBanned = false;
        }
    }

    public class DataBase
    {
        private Dictionary<int, PlayerData> _players = new ();
        private int _lastId = 0;

        public void AddNewPlayer(string name)
        {
            PlayerData player = new (name);
            _lastId++;
            _players.Add(_lastId, player);
        }

        public void SetBan(int id, bool ban)
        {
            var player = _players[id];
            player.IsBanned = ban;
            _players[id] = player;
        }

        public void RemovePlayer(int id)
        {
            _players.Remove(id);
        }

        public Dictionary<int, PlayerData> GetPlayers()
        {
            Dictionary<int, PlayerData> players = new();

            foreach (int id in _players.Keys)
            {
                PlayerData player = _players[id];
                players.Add(id, player);
            }

            return players;
        }
    }

    internal class Program
    {
        const char CommandAddPlayer = '1';
        const char CommandBanPlayer = '2';
        const char CommandUnbanPlayer = '3';
        const char CommandDeletePlayer = '4';
        const char CommandShowPlayer = '5';
        const char CommandExit = '6';

        private static int GetId()
        {
            Console.WriteLine("Введите ID: ");
            Int32.TryParse(Console.ReadLine(), out int id);
            return id;
        }

        private static string GetName()
        {
            Console.WriteLine("Введите имя игрока");
            return Console.ReadLine();
        }

        private static void ShowplayersInfo(DataBase playersData)
        {
            var players = playersData.GetPlayers();

            foreach (int id in players.Keys)
            {
                Console.WriteLine($"{id} - name:{players[id].Name} ban:{players[id].IsBanned}");
            }
        }

        static void Main()
        {
            DataBase playersData = new DataBase();
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
                        string name = GetName();
                        playersData.AddNewPlayer(name);
                        break;

                    case CommandBanPlayer:
                        int id = GetId();
                        playersData.SetBan(id, true);
                        break;

                    case CommandUnbanPlayer:
                        id = GetId();
                        playersData.SetBan(id, false);
                        break;

                    case CommandDeletePlayer:
                        id = GetId();
                        playersData.RemovePlayer(id);
                        break;

                    case CommandShowPlayer:
                        ShowplayersInfo(playersData);
                        break;

                    case CommandExit:
                        isRunning = false;
                        Console.WriteLine("Завершение работы программы");
                        break;
                }

                Console.WriteLine("для продолжения нажмите любую кнопку");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
