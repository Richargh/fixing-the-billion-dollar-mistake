using System;
using Richargh.BillionDollar.Classic.Common.Error;

namespace Richargh.BillionDollar.Rop.Common.Rop
{
    public static class ResultExtensions
    {
        public static Result<TValue> AsNullable<TValue>(
            this TValue? value, string errorIfNull) 
            where TValue : notnull 
            => AsNullable(value, errorIfNull, new NoScope());
        public static Result<TValue> AsNullable<TValue, TScope>(
            this TValue? value, string errorIfNull, TScope scope) 
            where TValue : notnull where TScope : IScope 
            => value switch
            {
                null => Result<TValue>.OfFail(errorIfNull),
                _ => Result<TValue>.OfOk(value)
            };
        
        public static Result<TValue> AsOk<TValue, TScope>(this TValue value, TScope scope) 
            where TValue : notnull where TScope : IScope
            => Result<TValue>.OfOk(value);
        
        public static Result<TOut> Either<TIn, TOut>(
            this Result<TIn> result, 
            Func<TIn, Result<TOut>> onOk,
            Func<string, Result<TOut>> onFail) 
            where TIn : notnull 
            where TOut : notnull
            => result switch
            {
                Result<TIn>.Ok ok => onOk(ok.Value),
                Result<TIn>.Fail fail => onFail(fail.Error),
                // This should be impossible but the type system sadly allows this
                _ => throw new SwitchNotExhaustiveException(result)
            };

        public static Result<TOut> FlatMap<TIn, TOut>(
            this Result<TIn> result, 
            Func<TIn, TOut> onOk) 
            where TIn : notnull 
            where TOut : notnull 
            => Either(
                result,
                value => Result<TOut>.OfOk(onOk(value)),
                error => Result<TOut>.OfFail(error));
        
        public static Result<TOut> Map<TIn, TOut>(
            this Result<TIn> result, 
            Func<TIn, Result<TOut>> onOk)
            where TIn : notnull 
            where TOut : notnull
            => Either(
                result,
                onOk,
                Result<TOut>.OfFail);

        public static Result<TOut> Map2<TIn1, TIn2, TOut>(
            this Result<TIn1> result,
            Result<TIn2> other,
            Func<TIn1, TIn2, Result<TOut>> onOk)
            where TIn1 : notnull
            where TIn2 : notnull
            where TOut : notnull
        {
            if (result is Result<TIn1>.Ok ok1 && other is Result<TIn2>.Ok ok2)
                return onOk(ok1.Value, ok2.Value);
            else if(result is Result<TIn1>.Fail fail1)
                return Result<TOut>.OfFail(fail1.Error);
            else if (other is Result<TIn2>.Fail fail2)
                return Result<TOut>.OfFail(fail2.Error);
            else
                throw new DeveloperMistake("Did not cover all possibilities. " +
                                           $"Result {result.GetType()} or other {other.GetType()} had an unexpected type.");
        }
    }
}