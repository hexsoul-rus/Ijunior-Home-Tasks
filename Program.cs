using System;

namespace Task39Properties
{
    public interface IUnit
    {
        char View { get; }
        int XPosition { get; }
        int YPosition { get; }
    }

    public class Player : IUnit
    {
        public char View
        {
            get
            {
                return _view;
            }
            private set
            {
                if (value != _fieldView)
                    _view = value;
            }
        }
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
        private char _view = '@';
        private char _fieldView = ' ';

        public Player(char view, int xPosition, int yPosition)
        {
            View = view;
            XPosition = xPosition;
            YPosition = yPosition;
        }
    }

    public class Renderer
    {
        public void DrawUnit(IUnit unit)
        {
            Console.SetCursorPosition(unit.XPosition, unit.YPosition);
            Console.WriteLine(unit.View);
        }
    }

    internal class Program
    {
        static void Main()
        {
            Player player = new('#', 10, 10);
            Renderer renderer = new();
            renderer.DrawUnit(player);
        }
    }
}
