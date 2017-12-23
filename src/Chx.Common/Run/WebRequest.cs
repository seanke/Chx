using System.IO;
using System.Net;

namespace Chx.Common.Run
{
    public class WebRequest : IWebRequest
    {
        public int Timeout
        {
            get { return request.Timeout; }
            set { request.Timeout = value; }
        }
        public string UserAgent
        {
            get { return request.UserAgent; }
            set { request.UserAgent = value; }
        }
        public IWebProxy Proxy
        {
            get { return request.Proxy; }
            set { request.Proxy = value; }
        }
        public string Method
        {
            get { return request.Method; }
            set { request.Method = value; }
        }
        public string ContentType
        {
            get { return request.ContentType; }
            set { request.ContentType = value; }
        }
        public string Accept
        {
            get { return request.Accept; }
            set { request.Accept = value; }
        }

        private HttpWebRequest request { get; set; }


        public WebRequest(string Uri)
        {
            try
            {
                request = (HttpWebRequest)System.Net.WebRequest.Create(Uri);
            }
            catch { }
        }

        public string GetResponse(string requestBody)
        {
            if (requestBody == null) requestBody = "";

            using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                sw.Write(requestBody);

            return GetResponse();
        }

        public string GetResponse()
        {
            HttpWebResponse r = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(r.GetResponseStream()))
                return sr.ReadToEnd();
        }
    }
}
