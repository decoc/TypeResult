using NUnit.Framework;

namespace TypeResult.Tests
{
    public class ResultTest
    {
        [Test]
        public void CreateDefaultSuccess()
        {
            var result = Result.Ok();
            
            Assert.IsTrue(result.IsSuccess);
            Assert.IsFalse(result.IsFailure);
        }

        [Test]
        public void CreateSuccessWithValue()
        {
            var result = Result.Ok(100);
            
            Assert.IsTrue(result.IsSuccess);
            Assert.IsFalse(result.IsFailure);
            Assert.AreEqual(100, result.Value);
        }

        [Test]
        public void CreateDefaultFailure()
        {
            var result = Result.Fail("Reason");
            
            Assert.IsFalse(result.IsSuccess);
            Assert.IsTrue(result.IsFailure);
            
            Assert.AreEqual("Reason", result.Error.Reason);
        }
        
        [Test]
        public void CreateFailure()
        {
            var result = Result.Fail<MyError>(new MyError.Case1("Reason"));
            
            Assert.IsFalse(result.IsSuccess);
            Assert.IsTrue(result.IsFailure);
            
            switch (result.Error)
            {
                case MyError.Case1 case1:
                    Assert.AreEqual("Reason", case1.Reason);
                    break;
                default:
                    Assert.Fail();
                    break;
            }
        }
    }
}
