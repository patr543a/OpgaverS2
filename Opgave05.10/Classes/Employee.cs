using Opgave05._10.Interfaces;

namespace Opgave05._10.Classes
{
    public class Employee : Entity, IPayable
    {
        public Employee(int id)
            : base(id)
        { }

        public virtual decimal Earnings() => 10_000;

        public decimal GetPaymentAmount() => Earnings() * 0.85m;
    }
}
