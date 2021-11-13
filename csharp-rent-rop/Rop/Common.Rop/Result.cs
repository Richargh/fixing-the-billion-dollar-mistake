namespace Richargh.BillionDollar.Rop.Common.Rop
{
    public abstract class Result<TValue> where TValue : notnull
    {
        // private constructor so no one outside this class can instantiate
        private Result()
        {
        }

        // TODO remove ofOK from Result to avoid super-long types
        public static Ok OfOk(TValue value) => new Ok(value);
        public static Fail OfFail(string error) => new Fail(error);
        
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
            public string Error { get; }
            
            public Fail(string error)
            {
                Error = error;
            }
        }
    }
}
