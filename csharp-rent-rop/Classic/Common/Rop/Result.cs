using Richargh.BillionDollar.Classic.Common.Error;

namespace Richargh.BillionDollar.Classic.Common.Rop
{
    public abstract class Result<TValue> where TValue : notnull
    {
        // private constructor so no one outside this class can instantiate
        private Result()
        {
        }

        public sealed class Ok : Result<TValue>
        {
            public TValue Value { get; }
            
            public Ok(TValue value)
            {
                Value = value;
            }
        }
        
        public sealed class Fail : Result<TValue>
        {
            public Failure Failure { get; }
            
            public Fail(Failure failure)
            {
                Failure = failure;
            }
        }
    }
}
