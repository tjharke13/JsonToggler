using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JsonToggler;

namespace JsonToggler.Api
{
    public class JsonTogglerApiService
    {
        private List<IFeatureToggle> _featureToggles;

        public JsonTogglerApiService(JsonServiceInfo serviceInfo)
        {
            _featureToggles = this.GetFeatureToggles(serviceInfo);
            if (_featureToggles == null)
            {
                _featureToggles = new List<IFeatureToggle>();
            }
        }

        public T GetFeatureToggle<T>() where T : FeatureToggle, new()
        {
            string name = typeof(T).Name;

            var feature = _featureToggles.Where(w => w.GetType() == typeof(T)).FirstOrDefault();

            if (feature == null)
                feature = new T() { Name = name.Replace("_", " ").SplitCamelCase(" ") };

            return (T)feature;
        }

        private List<IFeatureToggle> GetFeatureToggles(JsonServiceInfo serviceInfo)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = serviceInfo.BaseAddress;

            var myTask = client.GetAsync(serviceInfo.Endpoint);
            var response = myTask.Result;

            var result = new List<IFeatureToggle>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resultJson = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<IFeatureToggle>>(resultJson, new FeatureToggleConverter(serviceInfo.RootAssembly, serviceInfo.FeatureToggleNamespace));
            }
            else
            {
                var responseMessage = response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }

   
}
