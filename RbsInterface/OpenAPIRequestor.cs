using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using RbsInterface.Model;

namespace RbsInterface
{
    public class OpenAPIRequestor
    {
        private readonly HttpClient client;

        public OpenAPIRequestor(bool isAuthenticationRequest)
        {
            this.client = new HttpClient();
            this.client.BaseAddress = isAuthenticationRequest
                ? new Uri("https://ob.natwest.useinfinite.io/")
                : new Uri("https://api.natwest.useinfinite.io/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json;charset=UTF-8"));
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

        public async Task<HttpResponseMessage> PostDataAsync(string address)
        {
            try
            {
                var response = await client.PostAsJsonAsync(new Uri(address), new AuthorisatonRequest());
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

