using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chx.Worker.Controllers
{
    public class JobsController : ApiController
    {
        [Route("v1/jobs")]
        [HttpPost]
        public HttpResponseMessage RunJob(HttpRequestMessage req)
        {
            throw new NotImplementedException();
        }
    }
}
