using System;
using System.Collections.Generic;

namespace Task31BraveNewWorld    
{
    public class Snake
    {
        public bool IsGrowing { get; private set; } = false;
        private readonly int[,] _map;
        private readonly int _mapLengthX;
        private readonly int _mapLengthY;
        private readonly char headView = '☻';
        private readonly char tailView = 'o';
        public int Length { get; private set; } = 1;
        private int _moveDY = 0;
        private int _moveDX = 1;
        private int _headPositionY = 0;
        private int _headPositionX = 0;

        public Snake (int length, int[,] map)
        {
            this.Length = length;
            _map = map;
            _mapLengthY = _map.GetLength(0);
            _mapLengthX = _map.GetLength(1);
        }

        public void ReDrawTail(int groundCount, char groundView)
        {
            for (int i = 0; i < _mapLengthY; i++)
            {
                for (int j = 0; j < _mapLengthX; j++)
                {
                    if (_map[i, j] == Length)
                    {
                        if (IsGrowing)
                            Length++;

                        _headPositionY = i + _moveDY;
                        _headPositionX = j + _moveDX;
                        Console.SetCursorPosition(j, i);
                        Console.Write(tailView);
                    }

                    if (_map[i, j] > groundCount)
                    {
                        if (IsGrowing == false)
                            _map[i, j]--;

                        if (_map[i, j] == groundCount)
                        {
                            Console.SetCursorPosition(j, i);
                            Console.Write(groundView);
                        }
                    }
                }
            }

            IsGrowing = false;
        }

        public bool TryReDrawHead(int groundCount, int fruitCount)
        {
            if (_headPositionY >= _mapLengthY)
                _headPositionY = 0;
            else if (_headPositionY < 0)
                _headPositionY = _mapLengthY - 1;

            if (_headPositionX >= _mapLengthX)
                _headPositionX = 0;
            else if (_headPositionX < 0)
                _headPositionX = _mapLengthX - 1;

            if (_map[_headPositionY, _headPositionX] != groundCount && _map[_headPositionY, _headPositionX] != fruitCount)                    
                return false;
            else if (_map[_headPositionY, _headPositionX] == fruitCount)                                                       
                IsGrowing = true;

            _map[_headPositionY, _headPositionX] = Length;
            Console.SetCursorPosition(_headPositionX, _headPositionY);
            Console.Write(headView);
            return true;
        }

        public void ChangeDirection(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    _moveDX = 0;
                    _moveDY = -1;
                    break;
                case ConsoleKey.DownArrow:
                    _moveDX = 0;
                    _moveDY = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    _moveDX = -1;
                    _moveDY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    _moveDX = 1;
                    _moveDY = 0;
                    break;
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            int[,] map = new int[,] { {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0, 0, 0, 0, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                      {-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1},
                                      {-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1},
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-2, 0, 0, 0, 0, 0, 0},
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                      { 0, 0, 0, 0, 0, 0, 1, 2, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                      {-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1},
                                      {-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1},
                                      {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0,-2, 0, 0, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}};
            int mapLengthY = map.GetLength(0);
            int mapLengthX = map.GetLength(1);
            int groundCount = 0;
            int fruitCount = -2;
            bool isPlaying = true;
            Dictionary<int, char> mapObjects = new() {{ -2, '@'}, { -1, '█'}, { 0, ' '}};
            Snake snake = new(3, map);

            Console.CursorVisible = false;

            DrawMap(map, mapObjects);

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    snake.ChangeDirection(key);
                }

                snake.ReDrawTail(groundCount, mapObjects[groundCount]);

                isPlaying = snake.TryReDrawHead(groundCount, fruitCount);

                if (snake.IsGrowing)
                {
                    PlaceNewFruit(groundCount, map, mapLengthY, mapLengthX, mapObjects[fruitCount]);
                }

                System.Threading.Thread.Sleep(200);
            }

            Console.SetCursorPosition(0,map.GetLength(0));
            Console.WriteLine("Game over");

        }

        private static void PlaceNewFruit(int groundCount, int[,] map, int lengthY, int lengthX, char fruitView)
        {
            int x, y;
            Random random = new();

            do
            {
                x = random.Next(0, lengthX);
                y = random.Next(0, lengthY);
            }
            while (map[y, x] != groundCount);

            map[y, x] = -2;
            Console.SetCursorPosition(x, y);
            Console.Write(fruitView);
        }

        private static void DrawMap(int[,] map, Dictionary<int, char> consoleView)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (consoleView.ContainsKey(map[i, j]))
                        Console.Write(consoleView[map[i, j]]);
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }
        }
    }
}
