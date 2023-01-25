namespace Opgave05.People
{
    public class Employee : Person
    {
        private string _position = string.Empty;
        private DateTime _hired;
        private decimal _salary;

        public string Position 
        { 
            get => _position; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid selling description", nameof(value));
                else if (value != _position)
                    _position = value;
            }
        }

        public DateTime Hired 
        { 
            get => _hired; 
            set
            {
                if (value < DateTime.UtcNow.Subtract(new TimeSpan(7305, 0, 0)))
                    throw new ArgumentOutOfRangeException(nameof(value), "Date cannot be earlier than 20 years ago");
                else if (value != _hired)
                    _hired = value;
            } 
        }

        public decimal Salary 
        { 
            get => _salary; 
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "A salary cannot be negative");
                else if (value != _salary)
                    _salary = value;
            }
        }

        public Employee(int id, string name, DateTime birthdate, string title, string position, DateTime hired, decimal salary)
            : base(id, name, birthdate, title)
        {
            Position = position;
            Hired = hired;
            Salary = salary;
        }

        public override string ToString() => $"{base.ToString()}, Position: {Position}, Hired: {Hired:F}, Salary: {Salary:c2}";

        public override string GetRating() => throw new NotImplementedException("This method is not intended to be called on employee");
    }
}
