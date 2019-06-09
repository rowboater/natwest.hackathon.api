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
using Newtonsoft.Json;
using RbsInterface.AccessModels;
using RbsInterface.Model;

namespace RbsInterface
{
    public class OpenAPIRequestor : IOpenAPIRequestor
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

        public HttpResponseMessage KeyExchange(string address)
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
                        new KeyValuePair<string, string>("client_id", "NOwU7XoB_j1J7JUK6B6jm6d8ufHX78UKAeD23lawR00="),
                        new KeyValuePair<string, string>("client_secret", "tTDtUt7b-ntp7bXm0Il_seml5Lh1gwo9sS-1RzWP56s="),
                        new KeyValuePair<string, string>("redirectUrl", "http://accesspay.localhost:4200"),
                        new KeyValuePair<string, string>("grant_type", "authorization_code"),
                        new KeyValuePair<string, string>("code", "")
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
                    postClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJtYXhfYWdlIjo4NjQwMCwiYXBwIjoiYWNjZXNzcGF5IiwiYXVkIjoiMjVjZmJmMzEtYmE2NS00NzU1LWFmZjItZGI4ODhkNzVmNzk5Iiwib3JnIjoiYWNjZXNzcGF5LmNvbSIsInNjb3BlIjoiYWNjb3VudHMiLCJpc3MiOiJuYXR3ZXN0LnVzZWluZmluaXRlLmlvIiwidG9rZW5fdHlwZSI6IkFDQ0VTU19UT0tFTiIsImlhdCI6MTU2MDAxMjc3MSwianRpIjoiYjYxZGUwMDEtZWQ1Zi00ZTJiLTllY2MtNTBlMWNmYTgzODBlIiwiY2xpZW50X2lkIjoiMjVjZmJmMzEtYmE2NS00NzU1LWFmZjItZGI4ODhkNzVmNzk5IiwidGVuYW50IjoiTmF0V2VzdCJ9.HuItRo4cvnuIuxASgNwVeBkhCL2cvb36qLGotgRZa_uNErWRXOS2XQyzhTafnNfibgnql-XdXeAYvLM7ctE6jVlJaULvi5bQ3En9BXMTFzFV7a7bDafFydDerbtHa1_x8NXPGQxXqR_HH8YUytEKkKY7d75qfBVp24KSH8VHPkuJ5q8HXrzlWcCFBdkbZEVEKLiLRcQsn9dG3cJvDgewXc__Uq2UdLN4TWZh06LdiyOtpmfUPS8tI2DVVpe5I-c-exT4iwYnsJY-OQcG0jPq2v52QGcRXlk3uA-Rv54-PzGUDuVIU00F0wc8q35c7kge6yOmLxkJvb-ci8GOAkCsCQ");
                    postClient.BaseAddress = new Uri("https://ob.natwest.useinfinite.io/");

                    Root consentPermissions = new Root();
                    return postClient.PostAsJsonAsync<Root>(new Uri(postClient.BaseAddress + address), consentPermissions).Result;
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

