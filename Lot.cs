using System;

namespace Task2
{
    public class Lot : IReadOnlyLot
    {
        public Goods Goods { get; private set; }
        public int Count { get; set; }

        public Lot(Goods goods, int count)
        {
            Goods = goods;
            Count = count;
        }

        public void Merge(Lot newLot)
        {
            if (newLot.Goods != Goods)
                throw new InvalidOperationException();
            Count += newLot.Count;
        }
    }

    public interface IReadOnlyLot
    {
        public Goods Goods { get; }
        public int Count { get; }
    }
}
