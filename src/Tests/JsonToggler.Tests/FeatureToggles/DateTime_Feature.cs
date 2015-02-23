using JsonToggler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JsonToggler.Tests.FeatureToggles
{
    public class DateTime_Feature : JsonFeatureToggler<DateTime_Feature>
    {
        public DateTime_Feature()
        { }

        public DateTime_Feature(IJsonTogglerSection jsonTogglerSection)
            : base(jsonTogglerSection)
        { }
    }
}
