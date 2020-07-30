namespace TypeResult.Tests
{
    public abstract class MyError : Error
    {
        public class Case1: MyError
        {
            public Case1(string reason = "") : base(reason)
            {
            }
        }
            
        public class Case2: MyError
        {
            public Case2(string reason = "") : base(reason)
            {
            }
        }

        protected MyError(string reason = "") : base(reason)
        {
        }
    }
}