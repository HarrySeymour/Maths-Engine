using Core.Modules.Pure;

namespace Core.Utils
{
    public sealed class Fraction : IComparable<Fraction>, IEquatable<Fraction>
    {
        public int Numerator { get; }
        public int Denominator { get; }
        public double Value { get; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            int hcf = NumberTheory.GetHcf(Math.Abs(numerator), denominator);
            Numerator = numerator / hcf;
            Denominator = denominator / hcf;

            Value = (double)Numerator / Denominator;
        }

        // Arithmetic Operations
        public static Fraction operator +(Fraction a, Fraction b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));

            int num = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int den = a.Denominator * b.Denominator;
            return new Fraction(num, den);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));

            return a + (-b);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));

            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));

            if (b.Numerator == 0)
                throw new DivideByZeroException("Cannot divide by a fraction with a value of zero.");

            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static Fraction operator -(Fraction a)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            return new Fraction(-a.Numerator, a.Denominator);
        }

        public static Fraction operator +(Fraction a)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            return a;
        }

        // Comparison & Equality
        public int CompareTo(Fraction other)
        {
            if (other is null) return 1;

            long left = (long)Numerator * other.Denominator;
            long right = (long)other.Numerator * Denominator;
            return left.CompareTo(right);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Fraction a, Fraction b) => !(a == b);
        public static bool operator <(Fraction a, Fraction b) => a is null ? b is not null : a.CompareTo(b) < 0;
        public static bool operator >(Fraction a, Fraction b) => a is not null && a.CompareTo(b) > 0;
        public static bool operator <=(Fraction a, Fraction b) => a is null || a.CompareTo(b) <= 0;
        public static bool operator >=(Fraction a, Fraction b) => a is null ? b is null : a.CompareTo(b) >= 0;

        public override bool Equals(object obj) => obj is Fraction f && Equals(f);

        public bool Equals(Fraction other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public Fraction Reciprocal()
        {
            if (Numerator == 0)
                throw new InvalidOperationException("Cannot invert a fraction with a numerator of zero.");

            return new Fraction(Denominator, Numerator);
        }

        public Fraction Abs() => new Fraction(Math.Abs(Numerator), Denominator);

        public (int Whole, Fraction Remaining) ToMixedFraction()
        {
            int whole = Numerator / Denominator;
            int remNum = Math.Abs(Numerator % Denominator);
            return (whole, new Fraction(remNum, Denominator));
        }

        // Parsing & Formatting
        public static Fraction Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException("Input string cannot be null or empty.", nameof(s));

            string[] parts = s.Split('/');
            if (parts.Length == 1 && int.TryParse(parts[0].Trim(), out int num))
                return new Fraction(num, 1);

            if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out num) && int.TryParse(parts[1].Trim(), out int den))
                return new Fraction(num, den);

            throw new FormatException("String was not in a valid fraction format (e.g. 'a/b' or 'a').");
        }

        public override string ToString()
        {
            return Denominator == 1 ? $"{Numerator}" : $"{Numerator}/{Denominator}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}