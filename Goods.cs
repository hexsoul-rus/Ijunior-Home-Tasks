using System;

namespace Task2
{
    public class Goods
    {
        public string Name { get; private set;}

        public Goods(string name)
        {
            if (name == "")
                throw new ArgumentException(nameof(name));
            Name = name;
        }
    }
}
