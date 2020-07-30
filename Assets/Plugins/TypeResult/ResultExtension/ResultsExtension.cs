using System;
using System.Collections.Generic;
using System.Linq;

namespace TypeResult
{
    public static class ResultsExtension
    {
        public static IEnumerable<Result<TValue, TError>> OnSuccessAny<TValue, TError>(
            this IEnumerable<Result<TValue, TError>> results, Action<IEnumerable<TValue>> action) where TError : Error
        {
            if (results.Any(result => result.IsSuccess))
                action(results.Where(result => result.IsSuccess).Select(result => result.Value));

            return results;
        }
        
        public static IEnumerable<Result<TValue, TError>> OnSuccessAll<TValue, TError>(
            this IEnumerable<Result<TValue, TError>> results, Action<IEnumerable<TValue>> action) where TError : Error
        {
            if (results.All(result => result.IsSuccess))
                action(results.Where(result => result.IsSuccess).Select(result => result.Value));

            return results;
        }
        
        public static IEnumerable<Result<TValue, TError>> OnFailureAny<TValue, TError>(
            this IEnumerable<Result<TValue, TError>> results, Action<IEnumerable<TError>> action) where TError : Error
        {
            if (results.Any(result => result.IsFailure))
                action(results.Where(result => result.IsFailure).Select(result => result.Error));

            return results;
        }
        
        public static IEnumerable<Result<TValue, TError>> OnFailureAll<TValue, TError>(
            this IEnumerable<Result<TValue, TError>> results, Action<IEnumerable<TError>> action) where TError : Error
        {
            if (results.All(result => result.IsFailure))
                action(results.Where(result => result.IsFailure).Select(result => result.Error));

            return results;
        }
        
        public static IEnumerable<Result<TValue, TError>> FilterSuccess<TValue, TError>(
            this IEnumerable<Result<TValue, TError>> results) where TError : Error
        {
            return results.Where(result => result.IsSuccess);
        }
        
        public static IEnumerable<Result<TValue, TError>> FilterFailure<TValue, TError>(
            this IEnumerable<Result<TValue, TError>> results) where TError : Error
        {
            return results.Where(result => result.IsFailure);
        } 
    }
}