using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeatureToggleExample.FeatureToggles.ApiJsonToggler;
using FeatureToggleExample.ViewModels.ApiJsonToggler;
using FeatureToggleExample.Infrastructure;
using JsonToggler.Api;

namespace FeatureToggleExample.Controllers
{
    public partial class ApiJsonTogglerController : Controller
    {
        // GET: ApiJsonToggler
        public virtual ActionResult Index()
        {
            var jsonServiceInfo = GetJsonServiceInfo();
            var service = new JsonTogglerApiService(jsonServiceInfo);

            var feature1 = service.GetFeatureToggle<SQL_Feature>();
            var feature2 = service.GetFeatureToggle<BasicFeature>();
            var feature3 = service.GetFeatureToggle<Filter_Feature>();
            var feature4 = service.GetFeatureToggle<DateFeature>();

            var isEnabled = feature2.IsEnabled();

            var listOfGuids = new List<Guid>();
            listOfGuids.Add(new Guid("00000000-0000-0000-0000-000000000001"));
            listOfGuids.Add(new Guid("00000000-0000-0000-0000-000000000002"));
            listOfGuids.Add(new Guid("00000000-0000-0000-0000-000000000003"));
            listOfGuids.Add(new Guid("00000000-0000-0000-0000-000000000004"));
            listOfGuids.Add(new Guid("00000000-0000-0000-0000-000000000005"));

            var result = feature3.FilterCollection<Guid, Guid>(listOfGuids, "").ToList();

            var vm = new ApiJsonFeatureViewModel() { BasicFeature = feature2, DateFeature = feature4, SQL_Feature = feature1, Filter_Feature = feature3, OriginalCollection = listOfGuids, UpdatedCollection = result };

            return View(vm);
        }

        private JsonServiceInfo GetJsonServiceInfo()
        {
            var jsonServiceInfo = new JsonServiceInfo();
            jsonServiceInfo.BaseAddress = new Uri("http://localhost/FeatureToggleAPI/");
            jsonServiceInfo.Endpoint = "api/ComplexFeatures?platform=Web";
            jsonServiceInfo.RootAssembly = "FeatureToggleExample";
            jsonServiceInfo.FeatureToggleNamespace = "FeatureToggleExample.FeatureToggles.ApiJsonToggler";

            return jsonServiceInfo;
        }
    }
}