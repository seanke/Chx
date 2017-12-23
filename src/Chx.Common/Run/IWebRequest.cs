using System.Net;

namespace Chx.Common.Run
{
    public interface IWebRequest
    {
        int Timeout { get; set; }
        string UserAgent { get; set; }
        IWebProxy Proxy { get; set; }
        string Method { get; set; }
        string ContentType { get; set; }
        string Accept { get; set; }

        string GetResponse(string requestBody);
        string GetResponse();
    }
}
