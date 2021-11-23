namespace Task2
{
    public class Warehouse : LotsList
    {
        public void Ship(Goods goods, int count)
        {
            AddToList(goods, count);
        }
    }
}
