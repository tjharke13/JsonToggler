using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using JsonToggler;
using System.IO;
using Newtonsoft.Json;

namespace JsonToggler.Api
{
    public class JsonTogglerApiService : BaseJsonTogglerService
    {
        public JsonTogglerApiService(JsonServiceInfo serviceInfo)
        {
            _featureToggles = this.GetFeatureToggles(serviceInfo);
            if (_featureToggles == null)
            {
                _featureToggles = new List<IFeatureToggle>();
            }
        }

        private List<IFeatureToggle> GetFeatureToggles(JsonServiceInfo serviceInfo)
        {
            var result = new List<IFeatureToggle>();

            var client = new WebClient();
            client.Headers.Add("content-type", "application/json");

            try
            {
                var response = client.DownloadString(serviceInfo.Url);
                result = JsonConvert.DeserializeObject<List<IFeatureToggle>>(response, new FeatureToggleConverter(serviceInfo.RootAssembly, serviceInfo.FeatureToggleNamespace));
            }
            catch (WebException exception)
            {
                string responseText;

                using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                }
            }

            return result;
        }
    }

   
}
