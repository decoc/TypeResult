using NUnit.Framework;

namespace TypeResult.Tests
{
    public class FluentExtensionTest
    {
        [Test]
        public void CreateSuccessWithFluentStyle()
        {
            Result.Ok().WithValue(100)
                .OnSuccess(val => Assert.AreEqual(100, val))
                .OnFailure(_ => Assert.Fail());
        }

        [Test]
        public void CreateFailureWithFluentStyle()
        {
            Result.Fail("Reason").WithError(new MyError.Case1("Reason"))
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

        [Test]
        public void CreateFailureMessageWithFluentStyle()
        {
            Result.Fail()
                .WithErrorReason("Reason")
                .OnSuccess(_ => Assert.Fail())
                .OnFailure(e => Assert.AreEqual("Reason", e.Reason));
        }
    }
}