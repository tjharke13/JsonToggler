using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using JsonToggler.Tests.FeatureToggles;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using JsonToggler;

namespace JsonToggler.Tests
{
    [TestClass]
    public class FilterFeatureTest : BaseTestHelper
    {
        [TestInitialize]
        public void Setup()
        {
            _config = new Mock<IJsonTogglerSection>();
        }

        [TestMethod]
        public void Feature_IsEnabledEqualsFalse_DataSet_ShouldFilterRecords()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.Web);
            var feature = new FilterFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());

            var guidDataSet = TestFilterData.GetFullGuidList();
            var originalGuids = guidDataSet.Tables[0].AsEnumerable().Select(s => s.Field<Guid>("ID"));

            var filteredResults = feature.GetFilteredGuidItems(guidDataSet).Tables[0].AsEnumerable().Select(s => s.Field<Guid>("ID"));
            var itemsToFilter = feature.FilterValues.Select(s => new Guid(s));

            foreach (var guidToFilter in itemsToFilter)
            {
                Assert.IsTrue(filteredResults.Where(w => w == guidToFilter).Count() == 0);
            }
        }

        [TestMethod]
        public void Feature_IsEnabled_DataSet_ShouldNotFilterRecords()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);
            var feature = new FilterFeature(jsonSettings);

            Assert.IsTrue(feature.IsEnabled());

            var guidDataSet = TestFilterData.GetFullGuidList();
            var originalGuids = guidDataSet.Tables[0].AsEnumerable().Select(s => s.Field<Guid>("ID"));

            var filteredResults = feature.GetFilteredGuidItems(guidDataSet).Tables[0].AsEnumerable().Select(s => s.Field<Guid>("ID"));
            var itemsToFilter = feature.FilterValues.Select(s => new Guid(s));

            foreach (var guidToFilter in itemsToFilter)
            {
                Assert.IsTrue(filteredResults.Where(w => w == guidToFilter).Count() > 0);
            }

            Assert.IsTrue(originalGuids.Count() == filteredResults.Count());
        }

        [TestMethod]
        public void Feature_IsEnabledEqualsFalse_Objects_ShouldFilterRecords()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.Web);
            var feature = new FilterFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());

            var guidObjects = TestFilterData.GetGuidObjects();
            var filteredResults = feature.GetFilteredGuidObjects(guidObjects);
            var itemsToFilter = feature.FilterValues.Select(s => new Guid(s));

            foreach (var guidToFilter in itemsToFilter)
            {
                Assert.IsTrue(filteredResults.Where(w => w.Id == guidToFilter).Count() == 0);
            }
        }

        [TestMethod]
        public void Feature_IsEnabledEqualsFalse_Objects_ShouldNotFilterRecords()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);
            var feature = new FilterFeature(jsonSettings);

            Assert.IsTrue(feature.IsEnabled());

            var guidObjects = TestFilterData.GetGuidObjects();
            var filteredResults = feature.GetFilteredGuidObjects(guidObjects);
            var itemsToFilter = feature.FilterValues.Select(s => new Guid(s));

            foreach (var guidToFilter in itemsToFilter)
            {
                Assert.IsTrue(filteredResults.Where(w => w.Id == guidToFilter).Count() > 0);
            }

            Assert.IsTrue(guidObjects.Count() == filteredResults.Count());
        }
    }

    public class GuidObjectResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
