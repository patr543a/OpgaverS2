using Opgave05.People;
using System.Xml.Linq;

namespace Opgave05.UnitTest
{
    public sealed class UnitTest3
    {
        [Fact]
        public void Employee_ValidPosition_ReturnsTrue()
        {
            _ = new Employee(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m);

            Assert.True(true);
        }

        [Fact]
        public void Employee_InvalidPosition_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Employee(1, "Valid", DateTime.UtcNow, "Valid", null!, DateTime.UtcNow, 1m));
        }

        [Fact]
        public void Employee_ValidHired_ReturnsTrue()
        {
            _ = new Employee(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m);

            Assert.True(true);
        }

        [Fact]
        public void Employee_InvalidHired_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Employee(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow.Subtract(new TimeSpan(7306, 0, 0)), 1m));
        }

        [Fact]
        public void Employee_ValidSalary_ReturnsTrue()
        {
            _ = new Employee(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m);

            Assert.True(true);
        }

        [Fact]
        public void Employee_InvalidSalary_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Employee(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, -1m));
        }

        [Fact]
        public void Employee_ValidPositionMutation_ReturnsTrue()
        {
            var e = new Employee(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m);
            e.Position = "Valid";

            Assert.True(true);
        }

        [Fact]
        public void Employee_InvalidPositionMutation_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var e = new Employee(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m);
                e.Position = null!;
            });
        }

        [Fact]
        public void Employee_ValidHiredMutation_ReturnsTrue()
        {
            var e = new Employee(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m);
            e.Hired = DateTime.UtcNow;

            Assert.True(true);
        }

        [Fact]
        public void Employee_InvalidHiredMutation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => 
            {
                var e = new Employee(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m);
                e.Hired = DateTime.UtcNow.Subtract(new TimeSpan(7306, 0, 0));
            });
        }

        [Fact]
        public void Employee_ValidSalaryMutation_ReturnsTrue()
        {
            var e = new Employee(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m);
            e.Salary = 1m;

            Assert.True(true);
        }

        [Fact]
        public void Employee_InvalidSalaryMutation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => 
            {
                var e = new Employee(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1m);
                e.Salary = -1m;
            });
        }

        [Fact]
        public void SalesPerson_GetPercentageOfSalaryAndSales_ReturnsTrue()
        {
            var s = new SalesPerson(1, "Valid", DateTime.UtcNow, "Valid", "Valid", DateTime.UtcNow, 1234m, 123.4m, "Valid");

            Assert.True(s.GetPercentageOfSalaryAndSales() == 10m);
        }

        [Fact]
        public void Employee_ToString_ReturnsTrue()
        {
            var d = DateTime.UtcNow;
            var e = new Employee(1, "Valid", d, "Valid", "Valid", d, 1m);

            Assert.True(e.ToString() == $"Id: 1, Name: Valid, Birthdate: {d:F}, Title: Valid, Position: Valid, Hired: {d:F}, Salary: 1,00 kr.");
        }
    }
}
