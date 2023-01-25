namespace Opgave05
{
    public class Sale
    {
        private SalesUnit[] _sales = Array.Empty<SalesUnit>();
        private decimal _total;
        private DateTime _soldDate;

        public SalesUnit[] Sales 
        { 
            get => _sales; 
            set
            {
                if (value == Array.Empty<SalesUnit>())
                    throw new ArgumentException("Array cannot be empty", nameof(value));
                else if (value != _sales)
                    _sales = value;
            } 
        }

        public decimal Total 
        { 
            get => _total; 
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "The total cannot be negative");
                else if (value != _total)
                    _total = value;
            }
        }

        public DateTime SoldDate 
        { 
            get => _soldDate; 
            set
            {
                if (value < DateTime.UtcNow.Subtract(new TimeSpan(1, 0, 0, 0)))
                    throw new ArgumentOutOfRangeException(nameof(value), "Date cannot be earlier than 1 day ago");
                else if (value != _soldDate)
                    _soldDate = value;
            }
        }

        public Sale(SalesUnit[] sales, decimal total, DateTime soldDate)
        {
            Sales = sales;
            Total = total;
            SoldDate = soldDate;
        }
    }
}
