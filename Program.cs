using System;
using System.IO;

namespace Lesson
{
    interface ILogger
    {
        void WriteError(string message);
    }

    class Program
    {
        static void Main(string[] args)
        {
            PathFinder log1 = new PathFinder(new FileLogWritter());
            PathFinder log2 = new PathFinder(new ConsoleLogWritter());
            PathFinder log3 = new PathFinder(new SecureConsoleLogWritter(new FileLogWritter()));
            PathFinder log4 = new PathFinder(new SecureConsoleLogWritter(new ConsoleLogWritter()));
            PathFinder log5 = new PathFinder(new ConsoleLogWritter(new SecureConsoleLogWritter(new FileLogWritter())));

        }
    }

    class PathFinder 
    {
        private ILogger _writter;

        public PathFinder(ILogger writter)
        {
            if (_writter == null)
                throw new ArgumentNullException(nameof(writter));
            _writter = writter;
        }

        public void Find() => _writter.WriteError("some error");
    }

    class ConsoleLogWritter : ILogger
    {
        ILogger _writter;

        public ConsoleLogWritter()
        {
            _writter = null;
        }

        public ConsoleLogWritter(ILogger writter)
        {
            _writter = writter;
        }

        public void WriteError(string message)
        {
            Console.WriteLine(message);
            if (_writter != null)
                _writter.WriteError(message);
        }
    }

    class FileLogWritter : ILogger
    {
        public void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class SecureConsoleLogWritter : ILogger
    {
        ILogger _writter;
        public SecureConsoleLogWritter(ILogger writter)
        {
            if (_writter == null)
                throw new ArgumentNullException(nameof(writter));
            _writter = writter;
        }
        public void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                _writter.WriteError(message);
            }
        }
    }
}