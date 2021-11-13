namespace Richargh.BillionDollar.Rop.Common.Rop
{
    public abstract class ScopedResult<TValue, TScope> where TValue : notnull where TScope : IScope
    {
        public TScope Scope { get; }
        
        // private constructor so no one outside this class can instantiate
        private ScopedResult(TScope scope)
        {
            Scope = scope;
        }

        // TODO remove ofOK from Result to avoid super-long types
        public static Ok OfOk(TValue value, TScope scope) => new Ok(value, scope);
        public static Fail OfFail(string error, TScope scope) => new Fail(error, scope);
        
        public sealed class Ok : ScopedResult<TValue, TScope>
        {
            public TValue Value { get; }
            
            public Ok(TValue value, TScope scope) : base(scope)
            {
                Value = value;
            }
        }
        
        public sealed class Fail : ScopedResult<TValue, TScope>
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
