using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Moq;
using JsonToggler.Tests.FeatureToggles;
using JsonToggler;

namespace JsonToggler.Tests
{
    [TestClass]
    public class EntitySpecificTests : BaseTestHelper
    {
        
        [TestInitialize]
        public void Setup()
        {
            _config = new Mock<IJsonTogglerSection>();
        }

        [TestMethod]
        public void Feature_CompanyThatExists_Int_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL);

            var feature = new EntitySpecificFeature(jsonSettings);
            var compId = (1).ToString();

            Assert.IsTrue(feature.IsEnabled(compId));
        }

        [TestMethod]
        public void Feature_CompanyThatDoesntExist_Int_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL);

            var feature = new EntitySpecificFeature(jsonSettings);
            var compId = (5).ToString();

            Assert.IsFalse(feature.IsEnabled(compId));
        }

        [TestMethod]
        public void Feature_CompanyThatExists_Long_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL);

            var feature = new EntitySpecificFeature(jsonSettings);
            var compId = (1234567891234).ToString();

            Assert.IsTrue(feature.IsEnabled(compId));
        }

        [TestMethod]
        public void Feature_CompanyThatDoesntExist_Long_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL);

            var feature = new EntitySpecificFeature(jsonSettings);
            var compId = (8888888888888).ToString();

            Assert.IsFalse(feature.IsEnabled(compId));
        }

        [TestMethod]
        public void Feature_CompanyThatExists_Guid_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL);

            var feature = new EntitySpecificFeature(jsonSettings);
            var compId = "00000000-0000-0000-0000-000000000000";

            Assert.IsTrue(feature.IsEnabled(compId));
        }

        [TestMethod]
        public void Feature_CompanyThatDoesntExist_Guid_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL);

            var feature = new EntitySpecificFeature(jsonSettings);
            var compId = Guid.NewGuid().ToString();

            Assert.IsFalse(feature.IsEnabled(compId));
        }
    }
}
