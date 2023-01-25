namespace Opgave05.People
{
    public class SalesPerson : Employee
    {
        private decimal _yearToDateSales = 0;
        private string _sellingItems = string.Empty;
        private Sale _sale = new(new SalesUnit[] { null! }, 0m, DateTime.UtcNow);

        public decimal YearToDateSales
        {
            get => _yearToDateSales;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "A sale cannot be negative");
                else if (value != _yearToDateSales)
                    _yearToDateSales = value;
            }
        }

        public string SellingItems
        { 
            get => _sellingItems; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid selling description", nameof(value));
                else if (value != _sellingItems)
                    _sellingItems = value;
            }
        }

        public Sale Sale 
        { 
            get => _sale; 
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));
                else if (value != _sale)
                    _sale = value;
            }
        }

        public SalesPerson(int id, string name, DateTime birthdate, string title, string position, DateTime hired, decimal salary, decimal yearToDateSales, string sellingItems, Sale sale)
            : base(id, name, birthdate, title, position, hired, salary)
        {
            YearToDateSales = yearToDateSales;
            SellingItems = sellingItems;
            Sale = sale;
        }

        public decimal GetPercentageOfSalaryAndSales() => _yearToDateSales / Salary * 100;

        public override string ToString() => $"{base.ToString()}, YtD sales: {YearToDateSales:c2}, Selling: {SellingItems}";

        public override string GetRating() => _yearToDateSales switch
        {
            >= 0 and <= 10_000 => $"{Name} er en udmærket sælger",
            > 10_000 and <= 250_000 => $"{Name} er en god sælger",
            > 250_000 and <= 1_000_000 => $"{Name} er en dygtig sælger",
            > 1_000_000 and <= 10_000_000 => $"{Name} er en fantastisk sælger",
            > 10_000_000 => $"{Name} er en uovertruffen sælger",
            _ => "Fejl",
        };
    }
}
