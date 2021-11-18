using System;

namespace Richargh.BillionDollar.Classic
{
    public record Months(int RawValue) : IComparable<Months>
    {
        public override string ToString() => $"{RawValue} Months";
        public int CompareTo(Months? other) => RawValue.CompareTo(other?.RawValue);
        
        public static bool operator > (Months left, Months right) => left.CompareTo(right) > 0;
        public static bool operator < (Months left, Months right) => left.CompareTo(right) < 0;

        public static Money operator +(Months left, Months right) => new(left.RawValue + right.RawValue);
        public static Money operator -(Months left, Months right) => new(left.RawValue - right.RawValue);
    }
}