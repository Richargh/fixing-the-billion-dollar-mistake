using System;
using Richargh.BillionDollar.Classic.Common.Error;

namespace Richargh.BillionDollar.Classic.Common.Rop
{
    public static class Results
    {
        public static Result<TValue>.Ok Ok<TValue>(TValue value) where TValue: notnull => new(value);
        public static Result<TValue>.Fail Fail<TValue>(string error) where TValue : notnull => new(error);
        public static Result<TValue>.Fail Fail<TValue>(Failure failure) where TValue : notnull => new(failure.Message);
        
        public static Result<TValue> AsResult<TValue>(
            this TValue? value, string errorIfNull) 
            where TValue : notnull 
            => value switch
            {
                null => Fail<TValue>(errorIfNull),
                _ => Ok(value)
            };
        public static Result<TValue> AsResult<TValue>(
            this TValue? value, Failure failureIfNull) 
            where TValue : notnull 
            => value switch
            {
                null => Fail<TValue>(failureIfNull.Message),
                _ => Ok(value)
            };
        
        public static Result<TValue> AsOk<TValue>(this TValue value) 
            where TValue : notnull
            => Ok(value);

        public static Result<TOut> Then<TIn, TOut>(
            this Result<TIn> result, 
            Func<TIn, TOut> onOk) 
            where TIn : notnull 
            where TOut : notnull 
            => Either(
                result,
                value => Ok(onOk(value)),
                Fail<TOut>);
        
        public static Result<T> ThenDo<T>(
            this Result<T> result, 
            Action<T> onOk) 
            where T : notnull 
            => Either(
                result,
                value => { onOk(value); return Ok(value); },
                Fail<T>);
        
        public static Result<TOut> ThenTry<TIn, TOut>(
            this Result<TIn> result, 
            Func<TIn, Result<TOut>> onOk)
            where TIn : notnull 
            where TOut : notnull
            => Either(
                result,
                onOk,
                Fail<TOut>);
        
        public static Result<(TIn, TOut)> ThenTryToPair<TIn, TOut>(
            this Result<TIn> result, 
            Func<TIn, Result<TOut>> onOk)
            where TIn : notnull 
            where TOut : notnull
        {
            var intermediate = Either(
                result,
                onOk,
                Fail<TOut>);
            if (result is Result<TIn>.Ok ok1 && intermediate is Result<TOut>.Ok ok2)
                return Ok((ok1.Value, ok2.Value));
            if(result is Result<TIn>.Fail fail1)
                return Fail<(TIn, TOut)>(fail1.Error);
            if (intermediate is Result<TOut>.Fail fail2)
                return Fail<(TIn, TOut)>(fail2.Error);
            
            throw new DeveloperMistake("Did not cover all possibilities." +
                                       $" {nameof(result)}:{result.GetType()}" +
                                       $" or {nameof(intermediate)}:{intermediate.GetType()}" +
                                       " had an unexpected type.");
        }

        public static Result<TOut> ThenUnpaired<TIn1, TIn2, TOut>(
            this Result<(TIn1, TIn2)> result,
            Func<TIn1, TIn2, TOut> onOk)
            where TIn1 : notnull
            where TIn2 : notnull
            where TOut : notnull
            => Either(
                result,
                valuePair => Ok(onOk(valuePair.Item1, valuePair.Item2)),
                Fail<TOut>);

        public static Result<TOut> Then2<TIn1, TIn2, TOut>(
            this Result<TIn1> result,
            Result<TIn2> other,
            Func<TIn1, TIn2, TOut> onOk)
            where TIn1 : notnull
            where TIn2 : notnull
            where TOut : notnull
            => Either2(
                result,
                other,
                (value1, value2) => Ok(onOk(value1, value2)),
                Fail<TOut>);

        public static Result<TOut> ThenTry2<TIn1, TIn2, TOut>(
            this Result<TIn1> result,
            Result<TIn2> other,
            Func<TIn1, TIn2, Result<TOut>> onOk)
            where TIn1 : notnull
            where TIn2 : notnull
            where TOut : notnull
            => Either2(
                result,
                other,
                onOk,
                Fail<TOut>);
        
        public static Result<TOut> Then3<TIn1, TIn2, TIn3, TOut>(
            this Result<TIn1> result,
            Result<TIn2> other1,
            Result<TIn3> other2,
            Func<TIn1, TIn2, TIn3, TOut> onOk)
            where TIn1 : notnull
            where TIn2 : notnull
            where TIn3 : notnull
            where TOut : notnull
            => Either3(
                result,
                other1,
                other2,
                (value1, value2, value3) => Ok(onOk(value1, value2, value3)),
                Fail<TOut>);
        
        public static Result<TOut> ThenTry3<TIn1, TIn2, TIn3, TOut>(
            this Result<TIn1> result,
            Result<TIn2> other1,
            Result<TIn3> other2,
            Func<TIn1, TIn2, TIn3, Result<TOut>> onOk)
            where TIn1 : notnull
            where TIn2 : notnull
            where TIn3 : notnull
            where TOut : notnull
            => Either3(
                result,
                other1,
                other2,
                onOk,
                Fail<TOut>);
                
        public static TOut Finally<TIn, TOut>(
            this Result<TIn> result,
            Func<TIn, TOut> onOk,
            Func<string, TOut> onFail) 
            where TIn : notnull 
            => result switch
            {
                Result<TIn>.Ok ok => onOk(ok.Value),
                Result<TIn>.Fail fail => onFail(fail.Error),
                // This should be impossible but the type system sadly allows this
                _ => throw new SwitchNotExhaustiveException(result)
            };
        
        private static Result<TOut> Either<TIn, TOut>(
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

        public static TOut Finally2<TIn1, TIn2, TOut>(
            this Result<TIn1> result, 
            Result<TIn2> other, 
            Func<TIn1, TIn2, TOut> onOk,
            Func<string, TOut> onFail) 
            where TIn1 : notnull 
            where TIn2 : notnull 
            where TOut : notnull
        {
            if (result is Result<TIn1>.Ok ok1 && other is Result<TIn2>.Ok ok2)
                return onOk(ok1.Value, ok2.Value);
            if(result is Result<TIn1>.Fail fail1)
                return onFail(fail1.Error);
            if (other is Result<TIn2>.Fail fail2)
                return onFail(fail2.Error);
            
            throw new DeveloperMistake("Did not cover all possibilities." +
                                       $" {nameof(result)}:{result.GetType()}" +
                                       $" or {nameof(other)}:{other.GetType()}" +
                                       " had an unexpected type.");
        }
        
        private static Result<TOut> Either2<TIn1, TIn2, TOut>(
            this Result<TIn1> result, 
            Result<TIn2> other, 
            Func<TIn1, TIn2, Result<TOut>> onOk,
            Func<string, Result<TOut>> onFail) 
            where TIn1 : notnull 
            where TIn2 : notnull 
            where TOut : notnull
        {
            if (result is Result<TIn1>.Ok ok1 && other is Result<TIn2>.Ok ok2)
                return onOk(ok1.Value, ok2.Value);
            if(result is Result<TIn1>.Fail fail1)
                return onFail(fail1.Error);
            if (other is Result<TIn2>.Fail fail2)
                return onFail(fail2.Error);
            
            throw new DeveloperMistake("Did not cover all possibilities." +
                                       $" {nameof(result)}:{result.GetType()}" +
                                       $" or {nameof(other)}:{other.GetType()}" +
                                       " had an unexpected type.");
        }
        
        public static TOut Finally3<TIn1, TIn2, TIn3, TOut>(
            this Result<TIn1> result, 
            Result<TIn2> other1, 
            Result<TIn3> other2, 
            Func<TIn1, TIn2, TIn3, TOut> onOk,
            Func<string, TOut> onFail) 
            where TIn1 : notnull 
            where TIn2 : notnull 
            where TIn3 : notnull 
            where TOut : notnull
        {
            if (result is Result<TIn1>.Ok ok1 && other1 is Result<TIn2>.Ok ok2 && other2 is Result<TIn3>.Ok ok3)
                return onOk(ok1.Value, ok2.Value, ok3.Value);
            if(result is Result<TIn1>.Fail fail1)
                return onFail(fail1.Error);
            if (other1 is Result<TIn2>.Fail fail2)
                return onFail(fail2.Error);
            if (other2 is Result<TIn3>.Fail fail3)
                return onFail(fail3.Error);
            
            throw new DeveloperMistake("Did not cover all possibilities." +
                                       $" {nameof(result)} {result.GetType()}" +
                                       $" or {nameof(other1)}:{other1.GetType()}" +
                                       $" or {nameof(other2)}:{other2.GetType()}" +
                                       " had an unexpected type.");
        }
        
        private static Result<TOut> Either3<TIn1, TIn2, TIn3, TOut>(
            this Result<TIn1> result, 
            Result<TIn2> other1, 
            Result<TIn3> other2, 
            Func<TIn1, TIn2, TIn3, Result<TOut>> onOk,
            Func<string, Result<TOut>> onFail) 
            where TIn1 : notnull 
            where TIn2 : notnull 
            where TIn3 : notnull 
            where TOut : notnull
        {
            if (result is Result<TIn1>.Ok ok1 && other1 is Result<TIn2>.Ok ok2 && other2 is Result<TIn3>.Ok ok3)
                return onOk(ok1.Value, ok2.Value, ok3.Value);
            if(result is Result<TIn1>.Fail fail1)
                return onFail(fail1.Error);
            if (other1 is Result<TIn2>.Fail fail2)
                return onFail(fail2.Error);
            if (other2 is Result<TIn3>.Fail fail3)
                return onFail(fail3.Error);
            
            throw new DeveloperMistake("Did not cover all possibilities." +
                                       $" {nameof(result)} {result.GetType()}" +
                                       $" or {nameof(other1)}:{other1.GetType()}" +
                                       $" or {nameof(other2)}:{other2.GetType()}" +
                                       " had an unexpected type.");
        }
        
    }
}