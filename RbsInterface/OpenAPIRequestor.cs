using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using RbsInterface.AccessModels;
using RbsInterface.Model;

namespace RbsInterface
{
    public class OpenAPIRequestor
    {
        private readonly HttpClient client;

        public OpenAPIRequestor()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri("https://api.natwest.useinfinite.io/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> MakeWebRequest(string address)
        {
            try
            {
                var response = await client.GetAsync(address);
                if (!response.IsSuccessStatusCode) throw new NotFoundException("Result not found");
                return await response.Content.ReadAsStringAsync();
            }
            catch (AggregateException exception)
            {
                throw new HttpException(404, "Service endpoint cannot be found", exception.InnerException);
            }
            catch (ArgumentNullException exception)
            {
                throw new HttpException(500, exception.Message, exception.InnerException);
            }
            catch (HttpRequestException exception)
            {
                throw new HttpException(500, exception.Message, exception.InnerException);
            }
        }

        public HttpResponseMessage PostAuthorisation(string address)
        {
            try
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    clientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) =>
                    {
                        return true;
                    };

                    HttpContent content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "client_credentials"),
                        new KeyValuePair<string, string>("client_id", "NOwU7XoB_j1J7JUK6B6jm6d8ufHX78UKAeD23lawR00="),
                        new KeyValuePair<string, string>("client_secret", "tTDtUt7b-ntp7bXm0Il_seml5Lh1gwo9sS-1RzWP56s="),
                        new KeyValuePair<string, string>("scope", "accounts")
                    });

                    content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");


                    HttpClient postClient = new HttpClient(clientHandler);
                    postClient.BaseAddress = new Uri("https://ob.natwest.useinfinite.io/");

                    return postClient.PostAsync(new Uri(postClient.BaseAddress + address), content).Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public HttpResponseMessage PostConsentRequest(string address)
        {
            try
            {
                using (var clientHandler = new HttpClientHandler())
                {
                    clientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) =>
                    {
                        return true;
                    };

                    HttpClient postClient = new HttpClient(clientHandler);
                    postClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    postClient.DefaultRequestHeaders.Add("x-fapi-financial-id", "0015800000jfwxXAAQ");
                    postClient.BaseAddress = new Uri("https://ob.natwest.useinfinite.io/");

                    Data consentPermissions = new Data();

                    return postClient.PostAsJsonAsync(new Uri(postClient.BaseAddress + address), consentPermissions).Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

}

