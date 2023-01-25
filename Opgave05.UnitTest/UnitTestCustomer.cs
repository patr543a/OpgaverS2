using Opgave05.People;

namespace Opgave05.UnitTest
{
    public class UnitTestCustomer
    {
        // New

        [Fact]
        public void Customer_ValidCreated_ReturnsTrue()
        {
            _ = new Customer(1, "Valid", DateTime.UtcNow, "Valid", DateTime.UtcNow, 1m);

            Assert.True(true);
        }

        [Fact]
        public void Customer_InvalidCreated_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Customer(1, "Valid", DateTime.UtcNow, "Valid", DateTime.UtcNow.Subtract(new TimeSpan(2, 0, 0, 0)), 1m));
        }

        [Fact]
        public void Customer_ValidSpent_ReturnsTrue()
        {
            _ = new Customer(1, "Valid", DateTime.UtcNow, "Valid", DateTime.UtcNow, 1m);

            Assert.True(true);
        }

        [Fact]
        public void Customer_InvalidSpent_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Customer(1, "Valid", DateTime.UtcNow, "Valid", DateTime.UtcNow, -1m));
        }

        // Mutation

        [Fact]
        public void Customer_ValidCreatedMutation_ReturnsTrue()
        {
            var c = new Customer(1, "Valid", DateTime.UtcNow, "Valid", DateTime.UtcNow.Subtract(new TimeSpan(1, 0, 0)), 1m);
            c.Created = DateTime.UtcNow;

            Assert.True(true);
        }

        [Fact]
        public void Customer_InvalidCreatedMutation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var c = new Customer(1, "Valid", DateTime.UtcNow, "Valid", DateTime.UtcNow, 1m);
                c.Created = DateTime.UtcNow.Subtract(new TimeSpan(2, 0, 0, 0));
            });
        }

        [Fact]
        public void Customer_ValidSpentMutation_ReturnsTrue()
        {
            var c = new Customer(1, "Valid", DateTime.UtcNow, "Valid", DateTime.UtcNow, 1m);
            c.Spent = 0m;

            Assert.True(true);
        }

        [Fact]
        public void Customer_InvalidSpentMutation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var c = new Customer(1, "Valid", DateTime.UtcNow, "Valid", DateTime.UtcNow, 1m);
                c.Spent = -1m;
            });
        }

        // Others

        [Fact]
        public void Customer_ToString_ReturnsTrue()
        {
            var d = DateTime.UtcNow;
            var c = new Customer(1, "Valid", d, "Valid", d, 12.5m);
            Assert.True(c.ToString() == $"Id: 1, Name: Valid, Birthdate: {d:F}, Title: Valid, Created: {d:F}, Spent: 12,50 kr.");
        }
    }
}
