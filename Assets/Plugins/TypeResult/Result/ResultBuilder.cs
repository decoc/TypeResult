namespace TypeResult
{
    public static class Result
    {
        public static Result<Unit, Error> Ok()
        {
            return new Result<Unit, Error>(Unit.Default);
        }
        
        public static Result<TValue, Error> Ok<TValue>(TValue value)
        {
            return new Result<TValue, Error>(value);
        }
        
        public static Result<TValue, TError> Ok<TValue, TError>(TValue value) where TError : Error
        {
            return new Result<TValue, TError>(value);
        }

        public static Result<Unit, Error> Fail(string reason = "")
        {
            return new Result<Unit, Error>(new Error(reason));
        }
        
        public static Result<TValue, Error> Fail<TValue>(string reason = "")
        {
            return new Result<TValue, Error>(new Error(reason));
        }
        
        public static Result<Unit, Error> Fail<TError>(TError error) where TError : Error
        {
            return new Result<Unit, Error>(error);
        }
        
        public static Result<TValue, TError> Fail<TValue, TError>(TError error) where TError : Error
        {
            return new Result<TValue, TError>(error);
        }
    }
}