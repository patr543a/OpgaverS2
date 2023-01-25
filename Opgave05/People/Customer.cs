namespace Opgave05.People
{
    public class Customer : Person
    {
        private DateTime _created;
        private decimal _spent;

        public DateTime Created 
        { 
            get => _created; 
            set {
                if (value < DateTime.UtcNow.Subtract(new TimeSpan(1, 0, 0, 0)))
                    throw new ArgumentOutOfRangeException(nameof(value), "Date cannot be earlier than 1 day ago");
                else if (value != _created)
                    _created = value;
            } 
        }

        public decimal Spent
        {
            get => _spent; 
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Spent cannot be negative");
                else if (value != _spent)
                    _spent = value;
            } 
        }

        public Customer(int id, string name, DateTime birthdate, string title, DateTime created, decimal spent)
            : base(id, name, birthdate, title)
        {
            Created = created;
            Spent = spent;
        }

        public override string ToString() => $"{base.ToString()}, Created: {Created:F}, Spent: {Spent:c2}";

        public override string GetRating() => (_spent / (_created.Year * 12 + _created.Month)) switch
        {
            >= 0 and <= 100 => "*",
            > 100 and <= 250 => "**",
            > 250 and <= 500 => "***",
            > 500 and <= 1000 => "****",
            > 1000 => "*****",
            _ => "Fejl",
        };
    }
}
