using System;

namespace TypeResult
{
    public static class ResultExtension
    {
        public static (TValue Value, TError error) OnSuccess<TValue, TError>(this (TValue value, TError error) result, Action<TValue> action)
        {
            if (result.error == null)
                action(result.value);

            return result;
        }
        
        public static (TValue Value, TError error) OnFailure<TValue, TError>(this (TValue value, TError error) result, Action<TError> action) where TError : Error
        {
            if (result.error != null)
                action(result.error);

            return result;
        }        
        
        public static Result<TValue, TError> OnSuccess<TValue, TError>(this Result<TValue, TError> result, Action<TValue> action) where TError : Error
        {
            if (result.IsSuccess)
                action(result.Value);

            return result;
        }
        
        public static Result<TValue, TError> OnFailure<TValue, TError>(this Result<TValue, TError> result, Action<TError> action) where TError : Error
        {
            if (result.IsFailure)
                action(result.Error);

            return result;
        }
        
        public static void Deconstruct<TValue, TError>(this Result<TValue, TError> result, out TValue value, out TError error) where TError : Error
        {
            value = result.Value;
            error = result.Error;
        }
    }
}
