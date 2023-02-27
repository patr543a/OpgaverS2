namespace Opgave05._10.Classes
{
    public class SalesRepresentative : BaseSalariedEmployee
    {
        protected decimal _weeklySales;
        protected double _commisionRate;

        public SalesRepresentative(int id, decimal salary, decimal weeklySales, double commisionRate)
            : base(id, salary)
        {
            _weeklySales = weeklySales;
            _commisionRate = commisionRate;
        }

        public override decimal Earnings() => _salary;
    }
}