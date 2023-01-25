namespace Opgave05
{
    public abstract class SalesUnit
    {
        private string _name = string.Empty;
        private DateTime _created;
        private decimal _price;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid name", nameof(value));
                else if (value != _name)
                    _name = value;
            }
        }

        public DateTime Created
        {
            get => _created;
            set
            {
                if (value < DateTime.UtcNow.Subtract(new TimeSpan(1, 0, 0, 0)))
                    throw new ArgumentOutOfRangeException(nameof(value), "Date cannot be earlier than 1 day ago");
                else if (value != _created)
                    _created = value;
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "The price cannot be negative");
                else if (value != _price)
                    _price = value;
            }
        }

        public SalesUnit(string name, DateTime created, decimal price)
        {
            Name = name;
            Created = created;
            Price = price;
        }
    }
}
