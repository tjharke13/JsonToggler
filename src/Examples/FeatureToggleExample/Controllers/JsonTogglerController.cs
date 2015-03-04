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

            var listOfObjects = GetListOfSomeObject();
            var result2 = feature3.FilterCollection<SomeObject, Guid>(listOfObjects, "Id").ToList();

            //This will do the opposite of the original filter... This will filter only if the feature is enabled.
            var result3 = feature3.FilterCollection<SomeObject, Guid>(listOfObjects, "Id", true).ToList();

            var vm = new JsonTogglerFeatureViewModel() { BasicFeature = feature2, SQLFeature = feature4, DateFeature = feature1, Filter_Feature = feature3, OriginalCollection = listOfGuids, UpdatedCollection = result };

            return View(vm);
        }

        private List<SomeObject> GetListOfSomeObject()
        {
            var result = new List<SomeObject>();

            result.Add(new SomeObject { Id = new Guid("00000000-0000-0000-0000-000000000001"), Name = "Test 1", CreateDate = DateTime.Now.AddDays(-30) });
            result.Add(new SomeObject { Id = new Guid("00000000-0000-0000-0000-000000000002"), Name = "Test 2", CreateDate = DateTime.Now.AddDays(-60) });
            result.Add(new SomeObject { Id = new Guid("00000000-0000-0000-0000-000000000003"), Name = "Test 3", CreateDate = DateTime.Now.AddDays(-15) });
            result.Add(new SomeObject { Id = new Guid("00000000-0000-0000-0000-000000000004"), Name = "Test 4", CreateDate = DateTime.Now.AddDays(-4) });
            result.Add(new SomeObject { Id = new Guid("00000000-0000-0000-0000-000000000005"), Name = "Test 5", CreateDate = DateTime.Now.AddDays(-8) });
            result.Add(new SomeObject { Id = new Guid("00000000-0000-0000-0000-000000000006"), Name = "Test 6", CreateDate = DateTime.Now.AddDays(-99) });
            result.Add(new SomeObject { Id = new Guid("00000000-0000-0000-0000-000000000007"), Name = "Test 7", CreateDate = DateTime.Now.AddDays(-2) });
            result.Add(new SomeObject { Id = new Guid("00000000-0000-0000-0000-000000000008"), Name = "Test 8", CreateDate = DateTime.Now.AddDays(-87) });
            result.Add(new SomeObject { Id = new Guid("00000000-0000-0000-0000-000000000009"), Name = "Test 9", CreateDate = DateTime.Now.AddDays(-3) });
            result.Add(new SomeObject { Id = new Guid("00000000-0000-0000-0000-000000000010"), Name = "Test 10", CreateDate = DateTime.Now.AddDays(-1) });

            return result;
        }
    }

    public class SomeObject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
    }
}