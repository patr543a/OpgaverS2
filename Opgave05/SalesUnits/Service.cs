namespace Opgave05.SalesUnits
{
    public class Service : SalesUnit
    {
        private string _description = string.Empty;
        private TimeSpan _duration;

        public string Description 
        { 
            get => _description; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid description", nameof(value));
                else if (value != _description)
                    _description = value;
            }
        }

        public TimeSpan Duration 
        { 
            get => _duration;
            set
            {
                if (value < new TimeSpan(0))
                    throw new ArgumentOutOfRangeException(nameof(value), "Duration cannot be negative");
                else if (value != _duration)
                    _duration = value;
            }
        }

        public Service(string name, DateTime created, decimal price, string description, TimeSpan duration)
            : base(name, created, price)
        {
            Description = description;
            Duration = duration;
        }
    }
}
