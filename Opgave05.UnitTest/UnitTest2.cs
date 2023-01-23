using Opgave05.People;

namespace Opgave05.UnitTest
{
    public sealed class UnitTest2
    {
        [Fact]
        public void SalesPerson_ValidSellingItems_ReturnsTrue()
        {
            _ = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "Valid");

            Assert.True(true);
        }

        [Fact]
        public void SalesPerson_InvalidSellingItems_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, null!));
        }

        [Fact]
        public void SalesPerson_ValidSellingItemsMutation_ReturnsTrue()
        {
            var s = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "V");
            s.SellingItems = "Valid";

            Assert.True(true);
        }

        [Fact]
        public void SalesPerson_InvalidSellingItemsMutation_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var s = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m, 1m, "Valid");
                s.SellingItems = null!;
            });
        }

        [Fact]
        public void Person_ValidBirthdate_ReturnsTrue()
        {
            _ = new Person(1, "Valid", DateTime.UtcNow, "Valid");

            Assert.True(true);
        }

        [Fact]
        public void Person_InvalidBirthdate_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Person(1, "Valid", DateTime.UtcNow.Subtract(new TimeSpan(73051, 0, 0)), "Valid"));
        }

        [Fact]
        public void Person_ValidBirthdateMutation_ReturnsTrue()
        {
            var p = new Person(1, "Valid", DateTime.UtcNow, "Valid");
            p.Birthdate = DateTime.UtcNow;

            Assert.True(true);
        }

        [Fact]
        public void Person_InvalidBirthdateMutation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var p = new Person(1, "Valid", DateTime.UtcNow, "Valid");
                p.Birthdate = DateTime.UtcNow.Subtract(new TimeSpan(73051, 0, 0));
            });
        }

        [Fact]
        public void Person_ValidTitle_ReturnsTrue()
        {
            _ = new Person(1, "Valid", DateTime.UtcNow, "Valid");

            Assert.True(true);
        }

        [Fact]
        public void Person_InvalidTitle_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Person(1, "Valid", DateTime.UtcNow, null!));
        }

        [Fact]
        public void Person_ValidTitleMutation_ReturnsTrue()
        {
            var p = new Person(1, "Valid", DateTime.UtcNow, "Valid");
            p.Title = "Valid";

            Assert.True(true);
        }

        [Fact]
        public void Person_InvalidTitleMutation_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var p = new Person(1, "Valid", DateTime.UtcNow, "Valid");
                p.Title = null!;
            });
        }
    }
}
