using JsonToggler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JsonToggler.Tests.FeatureToggles
{
    public class SQL_Feature : JsonFeatureToggler<SQL_Feature>
    {
        public SQL_Feature()
        { }

        public SQL_Feature(IJsonTogglerSection jsonTogglerSection)
            : base(jsonTogglerSection)
        { }
    }
}
