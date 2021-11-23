using System;
using System.Collections.Generic;

namespace Task2
{
    public class LotsList
    {
        public IReadOnlyList<IReadOnlyLot> Lots => _lots;
        private readonly List<Lot> _lots;

        public LotsList()
        {
            _lots = new List<Lot>();
        }

        public void AddToList(Goods goods, int count)
        {
            if (goods == null)
                throw new NullReferenceException(nameof(goods));
            var newLot = new Lot(goods, count);
            int lotIndex = FindLotIndex(goods);
            if (lotIndex == -1)
                _lots.Add(newLot);
            else
                _lots[lotIndex].Merge(newLot);
        }

        public int FindLotIndex(Goods goods)
        {
             return _lots.FindIndex(lot => lot.Goods == goods);
        }
    }
}
