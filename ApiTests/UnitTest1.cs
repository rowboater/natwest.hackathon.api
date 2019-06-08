using System.Threading;
using NUnit.Framework;
using RbsInterface;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEndpointAccess()
        {
            OpenAPIRequestor sut = new OpenAPIRequestor(true);
            var response = sut.PostDataAsync("token");

            throw new AbandonedMutexException();
        }
    }
}