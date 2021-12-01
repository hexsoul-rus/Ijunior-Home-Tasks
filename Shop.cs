using System;

namespace Task2
{
    public class Shop
    {
        public Warehouse Warehouse { get; private set; }

        public Shop(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new NullReferenceException(nameof(warehouse));
            Warehouse = warehouse;
        }

        public Cart Cart() => new Cart(Warehouse);
    }
}