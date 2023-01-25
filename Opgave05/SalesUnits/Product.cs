namespace Opgave05.SalesUnits
{
    public class Product : SalesUnit
    {
        private int _quantity;

        public int Quantity 
        { 
            get => _quantity; 
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "The quantity cannot be negative");
                else if (value != _quantity)
                    _quantity = value;
            }
        }

        public Product(string name, DateTime created, decimal price, int quantity)
            : base(name, created, price)
        {
            Quantity = quantity;
        }
    }
}
