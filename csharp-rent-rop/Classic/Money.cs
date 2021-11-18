using System;

namespace Richargh.BillionDollar.Classic
{
    public record Money(int Amount) : IComparable<Money>
    {
        public override string ToString() => $"{Amount} Money";
        
        public int CompareTo(Money? other) => Amount.CompareTo(other?.Amount);
        
        public static bool operator > (Money left, Money right) => left.CompareTo(right) > 0;
        public static bool operator < (Money left, Money right) => left.CompareTo(right) < 0;

        public static Money operator +(Money left, Money right) => new(left.Amount + right.Amount);
        public static Money operator -(Money left, Money right) => new(left.Amount - right.Amount);
    }
}