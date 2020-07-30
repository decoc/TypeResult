using NUnit.Framework;

namespace TypeResult.Tests
{
    public class ResultExtensionTest
    {
        [Test]
        public void ProcessOnSuccess()
        {
            Result.Ok()
                .OnSuccess(_ => Assert.Pass())
                .OnFailure(_ => Assert.Fail());
        }

        [Test]
        public void ProcessOnSuccessWithValue()
        {
            Result.Ok(100)
                .OnSuccess(val => Assert.AreEqual(100, val))
                .OnFailure(_ => Assert.Fail());
        }

        [Test]
        public void ProcessOnFailure()
        {
            Result.Fail("Reason")
                .OnSuccess(_ => Assert.Fail())
                .OnFailure(e => Assert.AreEqual("Reason",e.Reason));
        }
        
        [Test]
        public void ProcessOnFailureWithError()
        {
            Result.Fail<MyError>(new MyError.Case1("Reason"))
                .OnSuccess(_ => Assert.Fail())
                .OnFailure(e =>
                {
                    switch (e)
                    {
                        case MyError.Case1 case1:
                            Assert.AreEqual("Reason", case1.Reason);
                            break;
                        default:
                            Assert.Fail();
                            break;
                    }
                });
        }
    }
}