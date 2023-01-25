using Opgave05.SalesUnits;

namespace Opgave05.UnitTest
{
    public class UnitTestProduct
    {
        // New

        [Fact]
        public void Product_ValidQuantity_ReturnsTrue()
        {
            _ = new Product("Valid", DateTime.UtcNow, 1m, 1);

            Assert.True(true);
        }

        [Fact]
        public void Product_InvalidQuantity_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product("Valid", DateTime.UtcNow, 1m, -1));
        }

        // Mutation

        [Fact]
        public void Product_ValidQuantityMutation_ReturnsTrue()
        {
            var p = new Product("Valid", DateTime.UtcNow, 1m, 1);
            p.Quantity = 1;

            Assert.True(true);
        }

        [Fact]
        public void Product_InvalidQuantityMutation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var p = new Product("Valid", DateTime.UtcNow, 1m, 1);
                p.Quantity = -1;
            });
        }

        // Others
    }
}
