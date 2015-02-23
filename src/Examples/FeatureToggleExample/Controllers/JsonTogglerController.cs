using FeatureToggleExample.FeatureToggles.JsonToggler;
using FeatureToggleExample.ViewModels.JsonToggler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeatureToggleExample.Controllers
{
    public partial class JsonTogglerController : Controller
    {
        // GET: JsonToggler
        public virtual ActionResult Index()
        {
            var feature1 = new DateFeature();
            var feature2 = new BasicFeature();
            var feature3 = new Filter_Feature();
            var feature4 = new SQLFeature();

            var isEnabled = feature2.IsEnabled();

            var listOfGuids = new List<Guid>();
            listOfGuids.Add(new Guid("00000000-0000-0000-0000-000000000001"));
            listOfGuids.Add(new Guid("00000000-0000-0000-0000-000000000002"));
            listOfGuids.Add(new Guid("00000000-0000-0000-0000-000000000003"));
            listOfGuids.Add(new Guid("00000000-0000-0000-0000-000000000004"));
            listOfGuids.Add(new Guid("00000000-0000-0000-0000-000000000005"));

            var result = feature3.FilterCollection<Guid, Guid>(listOfGuids, "").ToList();

            var vm = new JsonTogglerFeatureViewModel() { BasicFeature = feature2, SQLFeature = feature4, DateFeature = feature1, Filter_Feature = feature3, OriginalCollection = listOfGuids, UpdatedCollection = result };

            return View(vm);
        }
    }
}