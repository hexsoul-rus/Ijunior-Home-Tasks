namespace Task2
{
    public class Order
    {
        public string Paylink { get; private set; }

        public Order(Cart cart)
        {
            Paylink = "http://pay.com/order?"+cart.GetHashCode();
        }
    }
}
