using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonToggler.Api
{
    public class JsonServiceInfo
    {
        public Uri BaseAddress { get; set; }

        public string Endpoint { get; set; }

        public string RootAssembly { get; set; }

        public string FeatureToggleNamespace { get; set; }

        public string Url
        {
            get
            {
                var baseAdd = !BaseAddress.ToString().EndsWith("/") ? BaseAddress.ToString() + "/" : BaseAddress.ToString();
                var endpoint = Endpoint.StartsWith("/") ? Endpoint.Remove(0, 1) : Endpoint;

                return baseAdd + endpoint;
            }
        }
    }
}
