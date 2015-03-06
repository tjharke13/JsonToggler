using JsonToggler;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToggler.Tests
{
    public class BaseTestHelper
    {
        protected Mock<IJsonTogglerSection> _config;

        public IJsonTogglerSection GetJsonSettings(EnvironmentEnum env, string applications = "All")
        {
            _config.Setup(c => c.Platform).Returns(PlatformEnum.Web);
            _config.Setup(c => c.Environment).Returns(env);
            _config.Setup(c => c.Applications).Returns(applications);

            return _config.Object;
        }

        public IJsonTogglerSection GetJsonSettings(EnvironmentEnum env, PlatformEnum platform, string applications = "All")
        {
            _config.Setup(c => c.Environment).Returns(env);
            _config.Setup(c => c.Platform).Returns(platform);
            _config.Setup(c => c.Applications).Returns(applications);

            return _config.Object;
        }
    }
}
