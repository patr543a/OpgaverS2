using Opgave05.SalesUnits;

namespace Opgave05.UnitTest
{
    public class UnitTestService
    {
        // New

        [Fact]
        public void Service_ValidDescription_ReturnsTrue()
        {
            _ = new Service("Valid", DateTime.UtcNow, 1m, "Valid", TimeSpan.Zero);

            Assert.True(true);
        }

        [Fact]
        public void Service_InvalidDescription_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Service("Valid", DateTime.UtcNow, 1m, null!, TimeSpan.Zero));
        }

        [Fact]
        public void Service_ValidDuration_ReturnsTrue()
        {
            _ = new Service("Valid", DateTime.UtcNow, 1m, "Valid", TimeSpan.Zero);

            Assert.True(true);
        }

        [Fact]
        public void Service_InvalidDuration_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Service("Valid", DateTime.UtcNow, 1m, "Valid", TimeSpan.Zero.Subtract(new TimeSpan(1))));
        }

        // Mutation

        [Fact]
        public void Service_ValidDescriptionMutation_ReturnsTrue()
        {
            var p = new Service("Valid", DateTime.UtcNow, 1m, "Valid", TimeSpan.Zero);
            p.Description = "Valid";

            Assert.True(true);
        }

        [Fact]
        public void Service_InvalidDescriptionMutation_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var p = new Service("Valid", DateTime.UtcNow, 1m, "Valid", TimeSpan.Zero);
                p.Description = null!;
            });
        }

        [Fact]
        public void Service_ValidDurationMutation_ReturnsTrue()
        {
            var p = new Service("Valid", DateTime.UtcNow, 1m, "Valid", TimeSpan.Zero);
            p.Duration = TimeSpan.Zero;

            Assert.True(true);
        }

        [Fact]
        public void Service_InvalidDurationMutation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var p = new Service("Valid", DateTime.UtcNow, 1m, "Valid", TimeSpan.Zero);
                p.Duration = TimeSpan.Zero.Subtract(new TimeSpan(1));
            });
        }

        // Others
    }
}
