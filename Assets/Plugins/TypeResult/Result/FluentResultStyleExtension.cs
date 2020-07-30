using System;

namespace TypeResult
{
    public static class FluentResultStyleExtension
    {
        public static Result<TValue, TError> WithValue<TValue, TError>(this Result<Unit, TError> result, TValue value) where TError : Error
        {
            if(result.IsFailure)
                throw new Exception("Failure with value is not allowed.");
            
            return new Result<TValue, TError>(value);
        }
        
        public static Result<TValue, TError> WithErrorReason<TValue, TError>(this Result<TValue, TError> result, string reason)
            where TError : Error
        {
            if(result.IsSuccess)
                throw new Exception("Success with error is not allowed.");

            result.Error.reason = reason;
            
            return result;
        }
        
        public static Result<TValue, TError> WithError<TValue, TError>(this Result<TValue, Error> result, TError error)
            where TError : Error
        {
            if(result.IsSuccess)
                throw new Exception("Success with error is not allowed.");

            return new Result<TValue, TError>(error);
        }
    }
}
