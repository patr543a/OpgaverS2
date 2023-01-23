namespace Opgave05.People
{
    public sealed class SalesPerson : Employee
    {
        private decimal _yearToDateSales = 0;
        private string _sellingItems = string.Empty;

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

        public SalesPerson(int id, string name, DateTime birthdate, string title, string position, DateTime hired, decimal salary, decimal yearToDateSales, string sellingItems)
            : base(id, name, birthdate, title, position, hired, salary)
        {
            YearToDateSales = yearToDateSales;
            SellingItems = sellingItems;
        }

        public decimal GetPercentageOfSalaryAndSales() => _yearToDateSales / Salary * 100;

        public override string ToString() => $"{base.ToString()}, YtD sales: {YearToDateSales:c2}, Selling: {SellingItems}";
    }
}
