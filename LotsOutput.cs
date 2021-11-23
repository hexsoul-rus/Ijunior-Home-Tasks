using System;
using System.Collections.Generic;

namespace Task2
{
    public static class LotsOutput
    {
        public static void WriteList(IReadOnlyList<IReadOnlyLot> lots)
        {
            foreach (var item in lots)
                Console.WriteLine("name:" + item.Goods.Name + " count:" + item.Count);
        }
    }
}