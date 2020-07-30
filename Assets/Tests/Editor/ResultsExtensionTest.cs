using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TypeResult.Tests
{
    public class ResultsExtensionTest
    {
        [Test]
        public void ProcessSuccessAny()
        {
            var results = new List<Result<int, Error>>()
            {
                Result.Ok<int, Error>(1),
                Result.Fail<int, Error>(new Error()),
                Result.Ok<int, Error>(100)
            };

            results
                .OnSuccessAny(_ => Assert.Pass())
                .OnSuccessAll(_ => Assert.Fail())
                .OnFailureAll(_ => Assert.Fail());
        }

        [Test]
        public void ProcessSuccessAll()
        {
            var results = new List<Result<int, Error>>()
            {
                Result.Ok<int, Error>(1),
                Result.Ok<int, Error>(10),
                Result.Ok<int, Error>(100)
            };
            
            results
                .OnSuccessAny(_ => Assert.Pass())
                .OnSuccessAll(_ => Assert.Pass())
                .OnFailureAny(_ => Assert.Fail())
                .OnFailureAll(_ => Assert.Fail());            
        }

        [Test]
        public void FilterSuccess()
        {
            var results = new List<Result<int, Error>>()
            {
                Result.Ok<int, Error>(1),
                Result.Fail<int, Error>(new Error()),
                Result.Ok<int, Error>(100)
            };

            var successes = results.FilterSuccess();

            Assert.IsNotNull(successes);
            Assert.AreEqual(2, successes.Count());
        }
        
        [Test]
        public void FilterFailure()
        {
            var results = new List<Result<int, Error>>()
            {
                Result.Ok<int, Error>(1),
                Result.Fail<int, Error>(new Error()),
                Result.Ok<int, Error>(100)
            };

            var fails = results.FilterFailure();

            Assert.IsNotNull(fails);
            Assert.AreEqual(1, fails.Count());
        }
    }
}