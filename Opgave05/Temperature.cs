using System.Text.Json;

namespace Opgave05
{
    public class Temperature : IComparable<Temperature>, IEquatable<Temperature>, ICloneable
    {
        public static Temperature Zero => new(0, TemperatureScale.Celsius);
        public static Temperature AbsoluteZero => new(0, TemperatureScale.Kelvin);
        public static Temperature PlanckTemperature => new(1.4168e32, TemperatureScale.Kelvin);

        private const double FiveOverNine = 5 / 9;
        private const double ZeroPoint = 273.15;

        private double _degrees;
        private TemperatureScale _scale;

        public Temperature(double degrees) : this(degrees, TemperatureScale.Celsius, TemperatureScale.Celsius) { }

        public Temperature(double degrees, TemperatureScale scale) : this(degrees, scale, scale) { }

        public Temperature(double degrees, TemperatureScale from, TemperatureScale to)
        {
            ToScale(degrees, from, to);

            if (this < AbsoluteZero)
                throw new ArgumentOutOfRangeException(nameof(degrees), "Temperature cannot be colder than absolute Zero (0 K)");

            if (this > PlanckTemperature)
                throw new ArgumentOutOfRangeException(nameof(degrees), "Temperature cannot be hotter than the planck temperature (1.4168 x 10^32 K)");
        }

        public object Clone() => DeepCopy();

        public int CompareTo(Temperature? other)
        {
            if (other is null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            var t1 = new Temperature(_degrees, _scale, TemperatureScale.Celsius);
            var t2 = new Temperature(other._degrees, other._scale, TemperatureScale.Celsius);

            return t1._degrees.CompareTo(t2._degrees);
        }

        public bool Equals(Temperature? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;
            else if (GetHashCode() == other.GetHashCode())
                return true;

            return false;
        }

        public override bool Equals(object? obj) => Equals(obj as Temperature);

        public override int GetHashCode() => _degrees.GetHashCode() ^ _scale.GetHashCode();

        public double ToCelsius()
        {
            return _degrees = _scale switch
            {
                TemperatureScale.Fahrenheit => (_degrees - 32) * FiveOverNine,
                TemperatureScale.Kelvin => _degrees - ZeroPoint,
                _ => _degrees,
            };
        }

        public double ToFahrenheit()
        {
            return _degrees = _scale switch
            {
                TemperatureScale.Celsius => _degrees * FiveOverNine + 32,
                TemperatureScale.Kelvin => (_degrees - ZeroPoint) * FiveOverNine + 32,
                _ => _degrees,
            };
        }

        public double ToKelvin()
        {
            return _degrees = _scale switch
            {
                TemperatureScale.Celsius => _degrees + ZeroPoint,
                TemperatureScale.Fahrenheit => (_degrees - 32) * FiveOverNine + ZeroPoint,
                _ => _degrees,
            };
        }

        public double ToScale(double degrees, TemperatureScale from, TemperatureScale to)
        {
            _scale = to;

            if (from == to)
            {
                _degrees = degrees;
                return degrees;
            }

            var t = new Temperature(degrees, from);

            return to switch
            {
                TemperatureScale.Celsius => t.ToCelsius(),
                TemperatureScale.Fahrenheit => t.ToFahrenheit(),
                TemperatureScale.Kelvin => t.ToKelvin(),
                _ => 0,
            };
        }

        public void SetScale(TemperatureScale scale) => ToScale(_degrees, _scale, scale);

        public Temperature ShallowCopy() => (Temperature)MemberwiseClone();

        public Temperature DeepCopy()
        {
            using var ms = new MemoryStream();

            JsonSerializer.Serialize(ms, this);

            ms.Position = 0;

            return JsonSerializer.Deserialize<Temperature>(ms)!;
        }

        public static Temperature Negate(Temperature t)
        {
            var other = new Temperature(t._degrees, t._scale, TemperatureScale.Celsius);

            other.ToScale(-other._degrees, TemperatureScale.Celsius, t._scale);

            return other;
        }

        public Temperature Add(Temperature other)
        {
            var t1 = new Temperature(_degrees, _scale, TemperatureScale.Celsius);
            var t2 = new Temperature(other._degrees, other._scale, TemperatureScale.Celsius);

            return new Temperature(t1._degrees + t2._degrees, t1._scale);
        }

        public Temperature Subtract(Temperature other) => Add(-other);

        public Temperature Multiply(Temperature other)
        {
            var t1 = new Temperature(_degrees, _scale, TemperatureScale.Celsius);
            var t2 = new Temperature(other._degrees, other._scale, TemperatureScale.Celsius);

            return new Temperature(t1._degrees * t2._degrees, t1._scale);
        }

        public Temperature Divide(Temperature other)
        {
            var t1 = new Temperature(_degrees, _scale, TemperatureScale.Celsius);
            var t2 = new Temperature(other._degrees, other._scale, TemperatureScale.Celsius);

            if (t2._degrees == 0)
                throw new DivideByZeroException("Cannot divide by 0");

            return new Temperature(t1._degrees / t2._degrees, t1._scale);
        }

        public static bool operator ==(Temperature left, Temperature right) => left.CompareTo(right) == 0;

        public static bool operator !=(Temperature left, Temperature right) => left.CompareTo(right) != 0;

        public static bool operator <(Temperature left, Temperature right) => left.CompareTo(right) < 0;

        public static bool operator <=(Temperature left, Temperature right) => left.CompareTo(right) <= 0;

        public static bool operator >(Temperature left, Temperature right) => left.CompareTo(right) > 0;

        public static bool operator >=(Temperature left, Temperature right) => left.CompareTo(right) >= 0;

        public static Temperature operator -(Temperature t) => Negate(t);

        public static Temperature operator +(Temperature left, Temperature right) => left.Add(right);

        public static Temperature operator -(Temperature left, Temperature right) => left.Subtract(right);

        public static Temperature operator *(Temperature left, Temperature right) => left.Multiply(right);

        public static Temperature operator /(Temperature left, Temperature right) => left.Divide(right);

        public static implicit operator Temperature(double n) => new(n);
    }
}
