using Opgave05.People;
using Opgave05.SalesUnits;

namespace Opgave05.UnitTest
{
    public class UnitTestSalesPerson
    {
        // New

        [Fact]
        public void SalesPerson_ValidSales_ReturnsTrue()
        {
            _ = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "Valid", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow));

            Assert.True(true);
        }

        [Fact]
        public void SalesPerson_InvalidSales_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, -1m, "Valid", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow)));
        }

        [Fact]
        public void SalesPerson_ValidSellingItems_ReturnsTrue()
        {
            _ = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "Valid", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow));

            Assert.True(true);
        }

        [Fact]
        public void SalesPerson_InvalidSellingItems_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, null!, new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow)));
        }

        [Fact]
        public void SalesPerson_ValidSale_ReturnsTrue()
        {
            _ = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "Valid", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow));

            Assert.True(true);
        }

        [Fact]
        public void SalesPerson_InvalidSale_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "Valid", null!));
        }

        // Mutation

        [Fact]
        public void SalesPerson_ValidSalesMutation_ReturnsTrue()
        {
            var s = new SalesPerson(0, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 0m, "Valid", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow));
            s.YearToDateSales = 1m;

            Assert.True(true);
        }

        [Fact]
        public void SalesPerson_InvalidSalesMutation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var s = new SalesPerson(0, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 0m, "Valid", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow));
                s.YearToDateSales = -1m;
            });
        }

        [Fact]
        public void SalesPerson_ValidSellingItemsMutation_ReturnsTrue()
        {
            var s = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "V", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow));
            s.SellingItems = "Valid";

            Assert.True(true);
        }

        [Fact]
        public void SalesPerson_InvalidSellingItemsMutation_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var s = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "Valid", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow));
                s.SellingItems = null!;
            });
        }

        [Fact]
        public void SalesPerson_ValidSaleMutation_ReturnsTrue()
        {
            var s = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "V", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow));
            s.Sale = new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow);

            Assert.True(true);
        }

        [Fact]
        public void SalesPerson_InvalidSaleMutation_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var s = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "Valid", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow));
                s.Sale = null!;
            });
        }

        // Others

        [Fact]
        public void SalesPerson_GetPercentageOfSalaryAndSales_ReturnsTrue()
        {
            var s = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1234m, 123.4m, "Valid", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow));

            Assert.True(s.GetPercentageOfSalaryAndSales() == 10m);
        }

        [Fact]
        public void SalesPerson_ToString_ReturnsTrue()
        {
            var d = DateTime.UtcNow;
            var s = new SalesPerson(1, "Valid", d, "Valid", "Valid", DateTime.UtcNow, 1m, 12.5m, "Valid", new Sale(new SalesUnit[] { new SalesUnit("Valid", DateTime.UtcNow, 1m) }, 1m, DateTime.UtcNow));

            Assert.True(s.ToString() == $"Id: 1, Name: Valid, Birthdate: {d:F}, Title: Valid, Position: Valid, Hired: {d:F}, Salary: 1,00 kr., YtD sales: 12,50 kr., Selling: Valid");
        }
    }
}
