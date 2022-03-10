using System;
using System.IO;

namespace Lesson
{
    interface ILogger
    {
        void WriteError(string message);
    }

    abstract class LogWritter : ILogger
    {
        private readonly ILogger _writter;

        public LogWritter()
        {
            _writter = null;
        }

        public LogWritter(ILogger writter)
        {
            _writter = writter;
        }

        public void WriteError(string message)
        {
            Output(message);
            if (_writter != null)
                _writter.WriteError(message);
        }

        protected abstract void Output(string message);
    }

    class ConsoleLogWritter : LogWritter
    {
        public ConsoleLogWritter() : base() { }
        public ConsoleLogWritter(ILogger writter) : base(writter) { }
        protected override void Output(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FileLogWritter : LogWritter
    {
        public FileLogWritter() : base() { }
        public FileLogWritter(ILogger writter) : base(writter) { }
        protected override void Output (string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class SecureConsoleLogWritter : ILogger
    {
        private readonly ILogger _writter;
        public SecureConsoleLogWritter(ILogger writter)
        {
            if (writter == null)
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

    class PathFinder
    {
        private readonly ILogger _writter;

        public PathFinder(ILogger writter)
        {
            if (writter == null)
                throw new ArgumentNullException(nameof(writter));
            _writter = writter;
        }

        public void Find() => _writter.WriteError("some error");
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
}