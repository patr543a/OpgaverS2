namespace Opgave05._10.Classes
{
    public class Product : Entity
    {
        protected string _name = string.Empty;
        protected decimal _price;
        protected int _quantity;

        public decimal Price 
        { 
            get => _price; 
            set => _price = value;
        }

        public Product(int id, string name, decimal price, int quantity)
            : base(id)
        {
            _name = name;
            _price = price;
            _quantity = quantity;
        }
    }
}
