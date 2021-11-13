using System;
using Richargh.BillionDollar.Classic.Common.Error;

namespace Richargh.BillionDollar.Rop.Common.Rop
{
    public static class ScopedResultExtensions
    {
        public static ScopedResult<TValue, NoScope> AsNullable<TValue>(
            this TValue? value, string errorIfNull) 
            where TValue : notnull 
            => AsNullable(value, errorIfNull, new NoScope());
        public static ScopedResult<TValue, TScope> AsNullable<TValue, TScope>(
            this TValue? value, string errorIfNull, TScope scope) 
            where TValue : notnull where TScope : IScope 
            => value switch
            {
                null => ScopedResult<TValue, TScope>.OfFail(errorIfNull, scope),
                _ => ScopedResult<TValue, TScope>.OfOk(value, scope)
            };
        
        public static ScopedResult<TValue, TScope> AsOk<TValue, TScope>(this TValue value, TScope scope) 
            where TValue : notnull where TScope : IScope
            => ScopedResult<TValue, TScope>.OfOk(value, scope);
        
        public static ScopedResult<TOut, TScope> Either<TIn, TOut, TScope>(
            this ScopedResult<TIn, TScope> scopedResult, 
            Func<TIn, ScopedResult<TOut, TScope>> onOk,
            Func<string, ScopedResult<TOut, TScope>> onFail) 
            where TIn : notnull 
            where TOut : notnull
            where TScope : IScope 
            => scopedResult switch
            {
                ScopedResult<TIn, TScope>.Ok ok => onOk(ok.Value),
                ScopedResult<TIn, TScope>.Fail fail => onFail(fail.Error),
                // This should be impossible but the type system sadly allows this
                _ => throw new SwitchNotExhaustiveException(scopedResult)
            };

        public static ScopedResult<TOut, TScope> FlatMap<TIn, TOut, TScope>(
            this ScopedResult<TIn, TScope> scopedResult, 
            Func<TIn, TOut> onOk) 
            where TIn : notnull 
            where TOut : notnull 
            where TScope : IScope 
            => Either(
                scopedResult,
                value => ScopedResult<TOut, TScope>.OfOk(onOk(value), scopedResult.Scope),
                error => ScopedResult<TOut, TScope>.OfFail(error, scopedResult.Scope));
        
        public static ScopedResult<TOut, TScope> Map<TIn, TOut, TScope>(
            this ScopedResult<TIn, TScope> scopedResult, 
            Func<TIn, ScopedResult<TOut, TScope>> onOk)
            where TIn : notnull 
            where TOut : notnull
            where TScope : IScope 
            => Either(
                scopedResult,
                onOk,
                error => ScopedResult<TOut, TScope>.OfFail(error, scopedResult.Scope));

        public static ScopedResult<TOut, TScope> Map2<TIn1, TIn2, TOut, TScope>(
            this ScopedResult<TIn1, TScope> scopedResult,
            ScopedResult<TIn2, TScope> other,
            Func<TIn1, TIn2, ScopedResult<TOut, TScope>> onOk)
            where TIn1 : notnull
            where TIn2 : notnull
            where TOut : notnull
            where TScope : IScope
        {
            if (scopedResult is ScopedResult<TIn1, TScope>.Ok ok1 && other is ScopedResult<TIn2, TScope>.Ok ok2)
                return onOk(ok1.Value, ok2.Value);
            else if(scopedResult is ScopedResult<TIn1, TScope>.Fail fail1)
                return ScopedResult<TOut, TScope>.OfFail(fail1.Error, scopedResult.Scope);
            else if (other is ScopedResult<TIn2, TScope>.Fail fail2)
                return ScopedResult<TOut, TScope>.OfFail(fail2.Error, scopedResult.Scope);
            else
                throw new DeveloperMistake("Did not cover all possibilities. " +
                                           $"Result {scopedResult.GetType()} or other {other.GetType()} had an unexpected type.");
        }
        
    }
}