using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using JsonToggler.Tests.FeatureToggles;
using JsonToggler;

namespace JsonToggler.Tests
{
    [TestClass]
    public class DateTimeFeatureTest : BaseTestHelper
    {
        [TestInitialize]
        public void Setup()
        {
            _config = new Mock<IJsonTogglerSection>();
        }

        [TestMethod]
        public void Feature_CommandLessThanNowByYear_IsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);
            var feature = new DateTimeFeature(jsonSettings);
            feature.Command = DateTime.UtcNow.AddYears(-1).ToString();

            Assert.IsTrue(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_CommandLessThanNow_IsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);
            var feature = new DateTimeFeature(jsonSettings);
            feature.Command = DateTime.UtcNow.AddDays(-1).ToString();

            Assert.IsTrue(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_CommandEqualToNow_IsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);
            var feature = new DateTimeFeature(jsonSettings);
            feature.Command = DateTime.UtcNow.ToString();

            Assert.IsTrue(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_CommandGreaterThanNow_IsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);
            var feature = new DateTimeFeature(jsonSettings);
            feature.Command = DateTime.UtcNow.AddDays(1).Date.ToString();

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_CommandGreaterThanNowByYear_IsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);
            var feature = new DateTimeFeature(jsonSettings);
            feature.Command = DateTime.UtcNow.AddYears(1).Date.ToString();

            Assert.IsFalse(feature.IsEnabled());
        }
    }
}
