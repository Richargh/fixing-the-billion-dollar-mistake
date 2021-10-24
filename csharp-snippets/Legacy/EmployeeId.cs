using System.Collections.Generic;

namespace Richargh.BillionDollar.Legacy
{
    public class EmployeeId : ValueObject
    {

        public readonly string RawValue;
        
        public EmployeeId(string rawValue)
        {
            RawValue = rawValue;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RawValue;
        }

        public override string ToString()
        {
            return RawValue;
        }
    }
}