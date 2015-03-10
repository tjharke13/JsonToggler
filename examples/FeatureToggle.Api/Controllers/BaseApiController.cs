using JsonToggler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeatureToggle.API.Controllers
{
    public class BaseApiController : ApiController
    {
        protected PropertyResponse VerifyProperties(PlatformEnum platform, EnvironmentEnum environment)
        {
            var response = new PropertyResponse();
            var errors = new List<string>();

            if (!Enum.IsDefined(typeof(EnvironmentEnum), environment))
                errors.Add("The 'environment' property is invalid.");

            if (!Enum.IsDefined(typeof(PlatformEnum), platform))
                errors.Add("The 'platform' property is invalid.");

            if(errors.Count > 0)
            {
                response.Message = "The request is invalid.";
                response.Errors = errors;
            }

            return response;
        }
    }

    public class PropertyResponse
    {
        public PropertyResponse()
        {
            Errors = new List<string>();
        }

        public string Message { get; set; }

        public List<string> Errors { get; set; }
    }
}
