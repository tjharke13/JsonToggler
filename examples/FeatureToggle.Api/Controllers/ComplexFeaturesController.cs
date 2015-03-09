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
    public class ComplexFeaturesController : BaseApiController
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ComplexFeaturesController()
        {
            _jsonTogglerService = new JsonTogglerService();
        }

        private JsonTogglerService _jsonTogglerService { get; set; }

        [HttpGet]
        public HttpResponseMessage Get(EnvironmentEnum environment, PlatformEnum platform, string application = "ALL")
        {
            log.DebugFormat("GetAllForPlatform: {0}", platform.ToString());

            HttpResponseMessage response;
            try
            {
                var validationResult = VerifyProperties(platform, environment);

                if (validationResult.Errors.Count > 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, validationResult);
                    return response;
                }

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

        [HttpGet]
        public HttpResponseMessage Disabled()
        {
            log.Debug("Get Disabled features called.");

            HttpResponseMessage response;
            try
            {
                var result = new List<IFeatureToggle>();
                var features = _jsonTogglerService.GetAllFeatureToggles();

                foreach (var feature in features)
                {
                    if (feature.Environment == EnvironmentEnum.NONE)
                        result.Add(feature);
                }

                response = Request.CreateResponse(HttpStatusCode.OK, result.OrderBy(o => o.Name));
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
