using NUnit.Framework;

namespace TypeResult.Tests
{
    public class TupleResultTest
    {
        [Test]
        public void DeconstructResultOk()
        {
            var (val, error) = Result.Ok();
            
            Assert.AreEqual(Unit.Default, val);
            Assert.IsNull(error);
        }

        [Test]
        public void DeconstructResultFail()
        {
            var (val, error) = Result.Fail("Reason");
            
            Assert.AreEqual(Unit.Default, val);
            Assert.NotNull(error);
            Assert.AreEqual("Reason",error.Reason);
        }
    }
}