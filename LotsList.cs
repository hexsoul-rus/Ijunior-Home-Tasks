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

        public void EditList(Goods goods, int count)
        {
            if (goods == null)
                throw new NullReferenceException(nameof(goods));
            var newLot = new Lot(goods, count);
            int lotIndex = FindLotIndex(goods);
            if (lotIndex == -1)
                _lots.Add(newLot);
            else
            {
                _lots[lotIndex].Merge(newLot);
                if (_lots[lotIndex].Count == 0)
                    _lots.RemoveAt(lotIndex);
            }
        }

        public int FindLotIndex(Goods goods)
        {
             return _lots.FindIndex(lot => lot.Goods == goods);
        }

        protected void ClearList()
        {
            _lots.Clear();
        }
    }
}
