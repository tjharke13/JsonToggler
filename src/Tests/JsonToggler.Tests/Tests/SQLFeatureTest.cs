using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using JsonToggler.Tests.FeatureToggles;
using JsonToggler;

namespace JsonToggler.Tests
{
    [TestClass]
    public class SQLFeatureTest : BaseTestHelper
    {
        [TestInitialize]
        public void Setup()
        {
            _config = new Mock<IJsonTogglerSection>();
        }

        //
        //These tests won't work unless you have a database setup.  These are an integration test
        //

        //[TestMethod]
        //public void Feature_CommandWithData_IsEnabled_ReturnsTrue()
        //{
        //    var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);
        //    var feature = new SQLFeature(jsonSettings);

        //    Assert.IsTrue(feature.IsEnabled());
        //}

        //[TestMethod]
        //public void Feature_CommandWithoutData_IsEnabled_ReturnsFalse()
        //{
        //    var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);
        //    var feature = new SQLFeature(jsonSettings);
        //    feature.Command = "SELECT CAST(COUNT(1) AS BIT) FROM [CompanyGroupRoot] WHERE Id = '12300000-0000-0000-0000-000000000000'";

        //    Assert.IsFalse(feature.IsEnabled());
        //}

        //[TestMethod]
        //public void Feature_CommandWithCaseSatement_IsEnabled_ReturnsTrue()
        //{
        //    var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);
        //    var feature = new SQLFeature(jsonSettings);
        //    feature.Command = "SELECT CASE WHEN COUNT(*) > 5 THEN 1 ELSE 0 END from CompanyGroupRoot";

        //    Assert.IsTrue(feature.IsEnabled());
        //}

        //[TestMethod]
        //public void Feature_CommandWithCaseSatement_IsEnabled_ReturnsFalse()
        //{
        //    var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);
        //    var feature = new SQLFeature(jsonSettings);
        //    feature.Command = "SELECT CASE WHEN COUNT(*) > 1000000 THEN 1 ELSE 0 END from CompanyGroupRoot";

        //    Assert.IsFalse(feature.IsEnabled());
        //}
    }
}
