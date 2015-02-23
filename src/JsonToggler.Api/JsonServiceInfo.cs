using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToggler.Api
{
    public class JsonServiceInfo
    {
        public Uri BaseAddress { get; set; }

        public string Endpoint { get; set; }

        public string RootAssembly { get; set; }

        public string FeatureToggleNamespace { get; set; }
    }
}
