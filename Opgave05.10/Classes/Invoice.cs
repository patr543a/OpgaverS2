using Opgave05._10.Interfaces;

namespace Opgave05._10.Classes
{
    public class Invoice : Entity, IPayable
    {
        protected List<Product> _products = new();

        public Invoice(int id, List<Product> products)
            : base(id)
        {
            _products = products;
        }

        public decimal GetPaymentAmount()
        {
            var total = 0m;

            foreach (var product in _products)
                total += product.Price;

            return total;
        }
    }
}
