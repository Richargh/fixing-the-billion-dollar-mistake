namespace Richargh.BillionDollar.Rop.Common.Rop
{
    public abstract class Result<TValue, TScope> where TValue : notnull where TScope : IScope
    {
        // private constructor so no one outside this class can instantiate
        public TScope Scope { get; }
        
        private Result(TScope scope)
        {
            Scope = scope;
        }

        // TODO remove ofOK from Result to avoid super-long types
        public static Ok OfOk(TValue value, TScope scope) => new Ok(value, scope);
        public static Fail OfFail(string error, TScope scope) => new Fail(error, scope);
        
        public sealed class Ok : Result<TValue, TScope>
        {
            public TValue Value { get; }
            
            public Ok(TValue value, TScope scope) : base(scope)
            {
                Value = value;
            }
        }
        
        public sealed class Fail : Result<TValue, TScope>
        {
            public string Error { get; }
            
            public Fail(string error, TScope scope) : base(scope)
            {
                Error = error;
            }
        }
    }
    
    public interface IScope
    {
    }

    public sealed class NoScope : IScope
    {
    }
}
