using System.Collections.Generic;
using System.Linq;

namespace Richargh.BillionDollar.Legacy
{
    /// <summary>
    /// A Value Object is determined not by its identity but by its values.
    /// A value object is equal to another value object if the type is the same and all the values (fields) of the object match the values of the other object. 
    /// This class is no longer needed if you upgrade the csproj .NET 5+ and C#9+, because the latter comes with records that serve the same purpose.
    ///
    /// Code taken from <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects">Microsoft</see>
    /// </summary>
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}