using FeatureToggleExample.FeatureToggles.Disconnected;
using FeatureToggleExample.Infrastructure;
using FeatureToggleExample.ViewModels.Disconnected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeatureToggleExample.Controllers
{
    public partial class DisconnectedApiToggleController : Controller
    {
        // GET: DisconnectedApiToggle
        public virtual ActionResult Index()
        {
            var service = new DisconnectedFeatureToggleService();

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

            var result = feature3.FilterRecords<Guid>(listOfGuids);

            var vm = new DisconnectedFeatureViewModel() { BasicFeature = feature2, DateFeature = feature4, SQL_Feature = feature1, Filter_Feature = feature3, OriginalCollection = listOfGuids, UpdatedCollection = result };

            return View(vm);
        }
    }
}