using JsonToggler;
using JsonToggler;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace FeatureToggle.API.Controllers
{
    public class ComplexFeaturesController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ComplexFeaturesController()
        {
            _jsonTogglerService = new JsonTogglerService();
        }

        private JsonTogglerService _jsonTogglerService { get; set; }

        [HttpGet]
        public HttpResponseMessage Get(PlatformEnum platform, string application = "ALL")
        {
            log.DebugFormat("GetAllForPlatform: {0}", platform.ToString());

            HttpResponseMessage response;
            try
            {
                var features = _jsonTogglerService.GetAllFeatureTogglesForPlatformAndApplication(platform, application);

                response = Request.CreateResponse(HttpStatusCode.OK, features);
            }
            catch (Exception ex)
            {
                log.Error("Error occurred", ex);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpGet]
        public HttpResponseMessage All()
        {
            log.Debug("Get All features");

            HttpResponseMessage response;
            try
            {
                var features = _jsonTogglerService.GetAllFeatureToggles();

                response = Request.CreateResponse(HttpStatusCode.OK, features);
            }
            catch (Exception ex)
            {
                log.Error("Error occurred", ex);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

    }        
}
