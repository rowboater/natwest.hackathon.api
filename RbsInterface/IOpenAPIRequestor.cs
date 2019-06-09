using System.Net.Http;
using System.Threading.Tasks;

namespace RbsInterface
{
    public interface IOpenAPIRequestor
    {
        Task<string> MakeWebRequest(string address);
        HttpResponseMessage PostAuthorisation(string address);
        HttpResponseMessage KeyExchange(string address);
        HttpResponseMessage PostConsentRequest(string address);
    }
}