using System;
using System.Collections.Generic;

namespace Task40PlayersDataBase
{
    public class PlayerData
    {
        public readonly string Name;
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

        public void AddNewPlayer(string name)
        {
            PlayerData player = new (name);
            _players.Add(_players.Count, player);
        }
        public void AddNewPlayer(int id, string name)
        {
            PlayerData player = new (name);
            _players.Add(id, player);
        }
        public void AddBan(int id)
        {
            _players[id].IsBanned = true;
        }
        public void RemoveBan(int id)
        {
            _players[id].IsBanned = false;
        }
        public void RemovePlayer(int id)
        {
            _players.Remove(id);
        }
    }
    internal class Program
    {
        static void Main()
        {
            DataBase data = new DataBase();

            data.AddNewPlayer(45, "Vasya");
        }
    }
}
