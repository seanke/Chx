using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;

namespace Chx.Common.Run
{
    public class HttpCheck : IActivityType
    {
        public string Uri { get; private set; }
        public string Method { get; private set; }
        public string Body { get; private set; }
        public string Proxy { get; private set; }
        public string UserAgent { get; private set; }
        public string Accept { get; private set; }
        public string ContentType { get; private set; }
        public int Timeout { get; private set; }
        public WebHeaderCollection Headers { get; private set; }
        public List<string> SearchFor { get; private set; }

        private bool hasPropertiesPopulated;

        public HttpCheck()
        {
            Headers = new WebHeaderCollection();
            SearchFor = new List<string>();
        }

        public ActivityResult Run(ActivityParameterSet ParameterSet)
        {
            PopulateProperties(ParameterSet);

            return Run(new WebRequest(Uri), ParameterSet);
        }

        public ActivityResult Run(IWebRequest webRequest, ActivityParameterSet ParameterSet)
        {
            if(!hasPropertiesPopulated)
                PopulateProperties(ParameterSet);

            ActivityResult result = new ActivityResult();

            var errors = getInvalidParameterErrors();
            if(errors.Count > 0)
            {
                result.Parameters.AddRange(errors);
                result.ActivityStatus = ActivityStatus.BadParameters;
                return result;
            }

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            IWebRequest request = webRequest;
            request.Timeout = Timeout;
            request.UserAgent = UserAgent;
            if (!string.IsNullOrWhiteSpace(Proxy)) request.Proxy = new WebProxy(Proxy);
            request.Method = Method;
            request.ContentType = ContentType;
            request.Accept = Accept;

            result.ActivityStatus = ActivityStatus.Crashed;

            string response = "";

            try
            {
                if (Method != "GET")
                {
                    response = request.GetResponse(Body);
                }
                else
                {
                    response = request.GetResponse();
                }
            }
            catch (WebException e)
            {
                result.ActivityStatus = ActivityStatus.Fail;
                result.Parameters.Add(new ActivityResultParameter("HTTP Error", e.Message));
                return result;
            }


            result.ActivityStatus = ActivityStatus.Success;

            foreach (var p in SearchFor)
            {
                if (!response.Contains(p))
                {
                    result.ActivityStatus = ActivityStatus.Fail;
                    result.Parameters.Add(new ActivityResultParameter("Could not find", p));
                }
            }

            if (result.ActivityStatus != ActivityStatus.Success)
            {
                result.Parameters.Add(new ActivityResultParameter("Response", response));
            }

            return result;
        }

        private void PopulateProperties(ActivityParameterSet ParameterSet)
        {
            Uri = ParameterSet.GetFirstParameterValue("uri");
            Method = ParameterSet.GetFirstParameterValue("method");
            Body = ParameterSet.GetFirstParameterValue("body");
            Proxy = ParameterSet.GetFirstParameterValue("proxy");
            UserAgent = ParameterSet.GetFirstParameterValue("useragent");
            Accept = ParameterSet.GetFirstParameterValue("accept");
            ContentType = ParameterSet.GetFirstParameterValue("contenttype");
            if (string.IsNullOrWhiteSpace(UserAgent)) UserAgent = "Chx HttpTest";

            if (string.IsNullOrWhiteSpace(Method))
                Method = "GET";
            else
                Method = Method.Trim().ToUpper();

            int timeout;
            if (Int32.TryParse(ParameterSet.GetFirstParameterValue("timeout"), out timeout))
                Timeout = timeout;
            else
                Timeout = 60000;

            foreach (var header in ParameterSet.GetParameterValues("header"))
            {
                if (string.IsNullOrWhiteSpace(header)) continue;

                var s = header.Split(new char[] { ':' }, 2);

                if (s.Length == 2)
                    Headers.Add(s[0], s[1]);
            }

            foreach (var s in ParameterSet.GetParameterValues("searchfor"))
            {
                if (!string.IsNullOrWhiteSpace(s))
                    SearchFor.Add(s);
            }

            hasPropertiesPopulated = true;
        }

        private List<ActivityResultParameter> getInvalidParameterErrors()
        {
            var errors = new List<ActivityResultParameter>();

            if (!System.Uri.IsWellFormedUriString(Uri, UriKind.Absolute))
            {
                errors.Add(new ActivityResultParameter("Could not start", "URI parameter is not valid"));
            }

            if (Proxy != null && !System.Uri.IsWellFormedUriString(Proxy, UriKind.Absolute))
            {
                errors.Add(new ActivityResultParameter("Could not start", "Proxy parameter is not valid"));
            }

            if (Timeout < 1)
            {
                errors.Add(new ActivityResultParameter("Could not start", "Timeout parameter is not valid"));
            }

            for (int i = 0; i < Headers.Count; i++)
            {
                foreach (var item in Headers.GetValues(i))
                {
                    if (string.IsNullOrWhiteSpace(item))
                        errors.Add(new ActivityResultParameter("Could not start", "A header is in the incorrect format"));
                }              
            }

            return errors;
        }
    }
}