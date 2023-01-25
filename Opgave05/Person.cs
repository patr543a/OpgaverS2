namespace Opgave05
{
    public abstract class Person
    {
        private int _id = 0;
        private string _name = string.Empty;
        private DateTime _birthdate;
        private string _title = string.Empty;

        public int Id 
        { 
            get => _id; 
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Id cannot be negative");
                else if (value != _id)
                    _id = value;
            }
        }

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

        public DateTime Birthdate
        { 
            get => _birthdate;
            set
            {
                if (value < DateTime.UtcNow.Subtract(new TimeSpan(73050, 0, 0)))
                    throw new ArgumentOutOfRangeException(nameof(value), "Date cannot be earlier than 200 years ago");
                else if (value != _birthdate)
                    _birthdate = value;
            }
        }

        public string Title 
        { 
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid name", nameof(value));
                else if (value != _title)
                    _title = value;
            }
        }

        public Person(int id, string name, DateTime birthdate, string title)
        {
            Id = id;
            Name = name;
            Birthdate= birthdate;
            Title = title;
        }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Birthdate: {Birthdate:F}, Title: {Title}";

        public abstract string GetRating();
    }
}