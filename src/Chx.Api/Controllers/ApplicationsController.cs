﻿using System;
using System.Net.Http;
using System.Web.Http;

namespace Chx.Api.Controllers
{
    [RoutePrefix("v1/applications")]
    public class ApplicationsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetApplicatios(HttpRequestMessage req)
        {
            throw new NotImplementedException(); 
        }
    }
}