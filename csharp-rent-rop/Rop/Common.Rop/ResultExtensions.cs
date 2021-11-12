using System;
using Richargh.BillionDollar.Classic.Common.Error;

namespace Richargh.BillionDollar.Rop.Common.Rop
{
    public static class ResultExtensions
    {
        public static Result<TValue, NoScope> AsNullable<TValue>(
            this TValue? value, string errorIfNull) 
            where TValue : notnull 
            => AsNullable(value, errorIfNull, new NoScope());
        public static Result<TValue, TScope> AsNullable<TValue, TScope>(
            this TValue? value, string errorIfNull, TScope scope) 
            where TValue : notnull where TScope : IScope 
            => value switch
            {
                null => Result<TValue, TScope>.OfFail(errorIfNull, scope),
                _ => Result<TValue, TScope>.OfOk(value, scope)
            };
        
        public static Result<TValue, TScope> AsOk<TValue, TScope>(this TValue value, TScope scope) 
            where TValue : notnull where TScope : IScope
            => Result<TValue, TScope>.OfOk(value, scope);
        
        public static Result<TOut, TScope> Either<TIn, TOut, TScope>(
            this Result<TIn, TScope> result, 
            Func<TIn, Result<TOut, TScope>> onOk,
            Func<string, Result<TOut, TScope>> onFail) 
            where TIn : notnull 
            where TOut : notnull
            where TScope : IScope 
            => result switch
            {
                Result<TIn, TScope>.Ok ok => onOk(ok.Value),
                Result<TIn, TScope>.Fail fail => onFail(fail.Error),
                // This should be impossible but the type system sadly allows this
                _ => throw new SwitchNotExhaustiveException(result)
            };

        public static Result<TOut, TScope> FlatMap<TIn, TOut, TScope>(
            this Result<TIn, TScope> result, 
            Func<TIn, TOut> onOk) 
            where TIn : notnull 
            where TOut : notnull 
            where TScope : IScope 
            => Either(
                result,
                value => Result<TOut, TScope>.OfOk(onOk(value), result.Scope),
                error => Result<TOut, TScope>.OfFail(error, result.Scope));
        
        public static Result<TOut, TScope> Map<TIn, TOut, TScope>(
            this Result<TIn, TScope> result, 
            Func<TIn, Result<TOut, TScope>> onOk)
            where TIn : notnull 
            where TOut : notnull
            where TScope : IScope 
            => Either(
                result,
                onOk,
                error => Result<TOut, TScope>.OfFail(error, result.Scope));

        public static Result<TOut, TScope> Map2<TIn1, TIn2, TOut, TScope>(
            this Result<TIn1, TScope> result,
            Result<TIn2, TScope> other,
            Func<TIn1, TIn2, Result<TOut, TScope>> onOk)
            where TIn1 : notnull
            where TIn2 : notnull
            where TOut : notnull
            where TScope : IScope
        {
            if (result is Result<TIn1, TScope>.Ok ok1 && other is Result<TIn2, TScope>.Ok ok2)
                return onOk(ok1.Value, ok2.Value);
            else if(result is Result<TIn1, TScope>.Fail fail1)
                return Result<TOut, TScope>.OfFail(fail1.Error, result.Scope);
            else if (other is Result<TIn2, TScope>.Fail fail2)
                return Result<TOut, TScope>.OfFail(fail2.Error, result.Scope);
            else
                throw new DeveloperMistake("Did not cover all possibilities. " +
                                           $"Result {result.GetType()} or other {other.GetType()} had an unexpected type.");
        }
        
    }
}