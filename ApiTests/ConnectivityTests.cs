using NUnit.Framework;
using RbsInterface;

namespace ApiTests
{
    public class ConnectivityTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckAuthorisation()
        {
           OpenAPIRequestor sut = new OpenAPIRequestor(true);
           var response = sut.PostAuthorisation("token");

           Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public void CheckConsent()
        {
            OpenAPIRequestor sut = new OpenAPIRequestor(true);
            var response = sut.PostConsentRequest("open-banking/v3.1/aisp/account-access-consents");

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}