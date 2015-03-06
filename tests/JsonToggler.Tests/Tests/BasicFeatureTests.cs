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
    public class BasicFeatureTests : BaseTestHelper
    {
        
        [TestInitialize]
        public void Setup()
        {
            _config = new Mock<IJsonTogglerSection>();
        }

        #region Root Feature

        [TestMethod]
        public void Feature_LOCALIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_DEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_QASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_STAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_PRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_DEVWebPlatformIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_PRODWebPlatformIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_DEVAndroidPlatformIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_PRODAndroidPlatformIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_DEViOSPlatformIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_PRODiOSPlatformIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_DEVWinPhonePlatformIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_PRODWinPhonePlatformIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_DEVDesktopPlatformIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_PRODDesktopPlatformIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.IsEnabled());
        }

        [TestMethod]
        public void Feature_LocalIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.IsEnabled());
        }

        #endregion

        #region SubFeature1

        [TestMethod]
        public void SubFeature1_LocalIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_1().IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_DEVIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_1().IsEnabled());

        }

        [TestMethod]
        public void SubFeature1_QASIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_1().IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_STAGEIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_1().IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_PRODIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_1().IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_WebPlatformLocalIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_1().IsEnabled());

        }

        [TestMethod]
        public void SubFeature1_WebPlatformDEVIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_1().IsEnabled());

        }

        [TestMethod]
        public void SubFeature1_WebPlatformQASIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_1().IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_WebPlatformSTAGEIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_1().IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_WebPlatformPRODIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_1().IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_AndroidPlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature1_AndroidPlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature1_AndroidPlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_AndroidPlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_AndroidPlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_iOSPlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature1_iOSPlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature1_iOSPlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_iOSPlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_iOSPlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_WinPhonePlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature1_WinPhonePlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature1_WinPhonePlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_WinPhonePlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_WinPhonePlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_DesktopPlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature1_DesktopPlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature1_DesktopPlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_DesktopPlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_1(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature1_DesktopPlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);
             var subFeat = feature.SubFeature_1(jsonSettings);
             Assert.IsFalse(subFeat.IsEnabled());
        }

        #endregion

        #region SubFeature2

        [TestMethod]
        public void SubFeature2_LocalIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_DEVIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_QASIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_STAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_PRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_WebPlatformLocalIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_WebPlatformDEVIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_WebPlatformQASIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_WebPlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_WebPlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_AndroidPlatformLocalIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_AndroidPlatformDEVIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_AndroidPlatformQASIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_AndroidPlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_AndroidPlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_iOSPlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_iOSPlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_iOSPlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_iOSPlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_iOSPlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_WinPhonePlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_WinPhonePlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_WinPhonePlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_WinPhonePlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_WinPhonePlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_DesktopPlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_DesktopPlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature2_DesktopPlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_DesktopPlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature2_DesktopPlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_2(jsonSettings).IsEnabled());
        }

        #endregion

        #region SubFeature3

        [TestMethod]
        public void SubFeature3_LocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_DEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_QASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_STAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_PRODIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_WebPlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_WebPlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_WebPlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_WebPlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_WebPlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Web);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_AndroidPlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_AndroidPlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_AndroidPlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_AndroidPlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_AndroidPlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Android);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_iOSPlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_iOSPlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_iOSPlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_iOSPlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_iOSPlatformPRODIsEnabled_ReturnsTrue()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.iOS);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsTrue(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_WinPhonePlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_WinPhonePlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_WinPhonePlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_WinPhonePlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_WinPhonePlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.WinPhone);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_DesktopPlatformLocalIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.LOCAL, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_DesktopPlatformDEVIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.DEV, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());

        }

        [TestMethod]
        public void SubFeature3_DesktopPlatformQASIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.QAS, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_DesktopPlatformSTAGEIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.STAGE, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        [TestMethod]
        public void SubFeature3_DesktopPlatformPRODIsEnabled_ReturnsFalse()
        {
            var jsonSettings = GetJsonSettings(EnvironmentEnum.PROD, PlatformEnum.Desktop);

            var feature = new BasicFeature(jsonSettings);

            Assert.IsFalse(feature.SubFeature_3(jsonSettings).IsEnabled());
        }

        #endregion

    }
}
