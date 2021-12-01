using System;

namespace Task2
{
    public class Cart : LotsList
    {
        private readonly Warehouse _warehouse;

        public Cart(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new NullReferenceException(nameof(warehouse));
            _warehouse = warehouse;
        }

        public Order Order()
        {
            Order order = new Order(this);
            WriteOff(_warehouse);
            ClearList();
            return order;
        }

        public void Add(Goods goods, int count)
        {
            int index = _warehouse.FindLotIndex(goods);
            if (index == -1)
                throw new InvalidOperationException();
            if (_warehouse.Lots[index].Count < count)
                throw new InvalidOperationException();
            EditList(goods, count);
        } 

        private void WriteOff(LotsList list)
        {
            foreach (var item in Lots)
            {
                list.EditList(item.Goods, -item.Count);
            }
        }
    }
}
