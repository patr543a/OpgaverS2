using Opgave05.People;

namespace Opgave05.UnitTest
{
    public sealed class UnitTestBase
    {
        [Fact]
        public void Person_ValidId_ReturnsTrue()
        {
            _ = new Person(1, "Valid", DateTime.UtcNow, "Valid");

            Assert.True(true);
        }

        [Fact]
        public void Person_InvalidId_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Person(-1, "Valid", DateTime.UtcNow, "Valid"));
        }

        [Fact]
        public void Person_ValidName_ReturnsTrue()
        {
            _ = new Person(1, "Valid", DateTime.UtcNow, "Valid");

            Assert.True(true);
        }

        [Fact]
        public void Person_InvalidName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Person(1, null!, DateTime.UtcNow, "Valid"));
        }

        [Fact]
        public void SalesPerson_ValidSales_ReturnsTrue()
        {
            _ = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "Valid");

            Assert.True(true);
        }

        [Fact]
        public void SalesPerson_InvalidSales_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, -1m, "Valid"));
        }

        [Fact]
        public void Person_ValidIdMutation_ReturnsTrue()
        {
            var p = new Person(0, "Valid", DateTime.UtcNow, "Valid");
            p.Id = 1;

            Assert.True(true);
        }

        [Fact]
        public void Person_InvalidIdMutation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var p = new Person(0, "Valid", DateTime.UtcNow, "Valid");
                p.Id = -1;
            });
        }

        [Fact]
        public void Person_ValidNameMutation_ReturnsTrue()
        {
            var p = new Person(0, "Valid", DateTime.UtcNow, "Valid");
            p.Name = "NewValid";

            Assert.True(true);
        }

        [Fact]
        public void Person_InvalidNameMutation_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var p = new Person(0, "Valid", DateTime.UtcNow, "Valid");
                p.Name = null!;
            });
        }

        [Fact]
        public void SalesPerson_ValidSalesMutation_ReturnsTrue()
        {
            var s = new SalesPerson(0, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 0m, "Valid");
            s.YearToDateSales = 1m;

            Assert.True(true);
        }

        [Fact]
        public void SalesPerson_InvalidSalesMutation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var s = new SalesPerson(0, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 0m, "Valid");
                s.YearToDateSales = -1m;
            });
        }

        [Fact]
        public void Person_ToString_ReturnsTrue()
        {
            var d = DateTime.UtcNow;
            var p = new Person(1, "Valid", d, "Valid");

            Assert.True(p.ToString() == $"Id: 1, Name: Valid, Birthdate: {d:F}, Title: Valid");
        }

        [Fact]
        public void SalesPerson_ToString_ReturnsTrue()
        {
            var d = DateTime.UtcNow;
            var s = new SalesPerson(1, "Valid", d, "Valid", "Valid", DateTime.UtcNow, 1m, 12.5m, "Valid");

            Assert.True(s.ToString() == $"Id: 1, Name: Valid, Birthdate: {d:F}, Title: Valid, Position: Valid, Hired: {d:F}, Salary: 1,00 kr., YtD sales: 12,50 kr., Selling: Valid");
        }
    }
}