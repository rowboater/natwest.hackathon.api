using System;
using System.Net;
using System.Net.Http;
using RbsInterface;
using RbsInterface.Model;
using RbsService.Data;

namespace RbsService
{
    public class NatWestService : INatWestService
    {
        public void EstablishConnection()
        {
            try
            {
                IOpenAPIRequestor requestor = new OpenAPIRequestor();
                requestor.PostAuthorisation("token");
                HttpResponseMessage response = requestor.PostConsentRequest("open-banking/v3.1/aisp/account-access-consents");
                if (response.IsSuccessStatusCode)
                {
                    var resultString = response.Content.ReadAsStringAsync().Result;
                    IConsentRepository repo = new ConsentRepository();
                    var consent = repo.Get(resultString);
                    AuthoriseConsent(consent.Data.ConsentId);
                    requestor.PostAuthorisation("https://ob.natwest.useinfinite.io/token");
                }
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, "Failure to establish connection to Banking Api");
            }
        }

        public void AuthoriseConsent(string consentId)
        {
            OpenAPIRequestor client = new OpenAPIRequestor();

            string baseAddress = "https://api.natwest.useinfinite.io/authorize";
            string clientId = "NOwU7XoB_j1J7JUK6B6jm6d8ufHX78UKAeD23lawR00=";
            string encodedRedirectUrl = "http%3A%2F%2Faccesspay.localhost%3A4200";
            string psuUsername = "123456789012@accesspay.com";
            string address =
                $"{baseAddress}?client_id={clientId}&response_type=code id_token&scope=openid accounts&redirect_uri={encodedRedirectUrl}&state=ABC&request={consentId}&authorization_mode=AUTO_POSTMAN&authorization_username={psuUsername}";

            var result = client.MakeWebRequest(address);
            // return Authorisation Code
        }


        public void ListAccounts(string customerId)
        {
            OpenAPIRequestor requestor = new OpenAPIRequestor();
            string uriPrefix = "https://ob.natwest.useinfinite.io/";
            string callAddress = "open-banking/v3.1/aisp/accounts";
            var response = requestor.MakeWebRequest($"{uriPrefix}{callAddress}");
            //Deserialise intooooo??
        }

        public void ListTransactions(string accountId)
        {
            OpenAPIRequestor requestor = new OpenAPIRequestor();
            string uriPrefix = "https://ob.natwest.useinfinite.io/";
            string callAddress = $"open-banking/v3.1/aisp/accounts/{accountId}/transactions";
            var response = requestor.MakeWebRequest($"{uriPrefix}{callAddress}");
            //Deserialise intooooo??
        }
    }
}
