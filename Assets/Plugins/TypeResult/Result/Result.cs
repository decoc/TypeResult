namespace TypeResult
{
    public class Result<TValue, TError> where TError : Error
    {
        public TValue Value { get; }
        public TError Error { get; }
        
        internal Result(TValue value)
        {
            Value = value;
        }

        internal Result(TError error)
        {
            Error = error;
        }

        public bool IsSuccess => !IsFailure;
        public bool IsFailure => Error != null;
    }
}