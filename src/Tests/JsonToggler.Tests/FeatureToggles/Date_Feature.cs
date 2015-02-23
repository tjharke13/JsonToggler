using JsonToggler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JsonToggler.Tests.FeatureToggles
{
    public class Date_Feature : JsonFeatureToggler<Date_Feature>
    {
        public Date_Feature()
        { }

        public Date_Feature(IJsonTogglerSection jsonTogglerSection)
            : base(jsonTogglerSection)
        { }
    }
}
