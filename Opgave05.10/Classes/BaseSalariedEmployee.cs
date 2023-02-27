namespace Opgave05._10.Classes
{
    public class BaseSalariedEmployee : Employee
    {
        protected decimal _salary;

        public BaseSalariedEmployee(int id, decimal salary)
            : base(id)
        {
            _salary = salary;
        }

        public override decimal Earnings() => _salary;
    }
}
