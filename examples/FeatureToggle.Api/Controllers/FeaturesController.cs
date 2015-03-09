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
    public class FeaturesController : BaseApiController
    {
         private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public FeaturesController()
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
                var propertyErrors = VerifyProperties(platform, environment);

                if(propertyErrors.Errors.Count > 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, propertyErrors);
                    return response;
                }

                var features = _jsonTogglerService.GetAllFeatureTogglesForPlatformAndApplication(platform, application);

                var ftResults = new List<FeatureToggleResult>();
                foreach(var feature in features)
                {
                    var ftResult = new FeatureToggleResult();
                    ftResult.Name = feature.Name;
                    ftResult.IsEnabled = feature.Platform.Has<PlatformEnum>(platform) && feature.Environment.Has<EnvironmentEnum>(environment);
                    ftResult.FilterValues = feature.FilterValues;
                    ftResult.CommandType = feature.CommandType.HasValue ? (int)feature.CommandType.Value : 0;
                    ftResult.Command = feature.Command;

                    if(feature.SubFeatureToggles != null && feature.SubFeatureToggles.Count > 0)
                    {
                        var subFeatures = new List<SubFeatureToggleResult>();
                        foreach (var subFeature in feature.SubFeatureToggles)
                        {
                            var subft = new SubFeatureToggleResult();

                            subft.Name = subFeature.Name;
                            subft.IsEnabled = subFeature.Platform.Has<PlatformEnum>(platform) && subFeature.Environment.Has<EnvironmentEnum>(environment);
                            subft.FilterValues = subFeature.FilterValues;
                            subft.CommandType = subFeature.CommandType.HasValue ? (int)subFeature.CommandType.Value : 0;
                            subft.Command = subFeature.Command;

                            subFeatures.Add(subft);
                        }

                        ftResult.SubFeatures = subFeatures;
                    }

                    ftResults.Add(ftResult);
                }

                response = Request.CreateResponse(HttpStatusCode.OK, ftResults);
            }
            catch (Exception ex)
            {
                log.Error("Error occurred", ex);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
    }

    public class FeatureToggleResult
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public int? CommandType { get; set; }

        public string Command { get; set; }

        public List<string> FilterValues { get; set; }

        public List<SubFeatureToggleResult> SubFeatures { get; set; }
    }

    public class SubFeatureToggleResult
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public int? CommandType { get; set; }

        public string Command { get; set; }

        public List<string> FilterValues { get; set; }
    }
    
}