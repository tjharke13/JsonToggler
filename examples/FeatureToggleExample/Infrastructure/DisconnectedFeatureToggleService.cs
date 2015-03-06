using FeatureToggleExample.FeatureToggles.Disconnected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace FeatureToggleExample.Infrastructure
{
    public class DisconnectedFeatureToggleService
    {
        private List<BaseFeatureToggle> _featureToggles;

        public DisconnectedFeatureToggleService()
        {
            _featureToggles = this.GetFeatureToggles();
            if (_featureToggles == null)
            {
                _featureToggles = new List<BaseFeatureToggle>();
            }
        }

        public T GetFeatureToggle<T>() where T : BaseFeatureToggle, new()
        {
            string name = typeof(T).Name;

            var feature = _featureToggles.Where(w => w.GetType() == typeof(T)).FirstOrDefault();

            if (feature == null)
                feature = new T() { Name = name.Replace("_", " ") };

            return (T)feature;
        }

        public List<BaseFeatureToggle> GetFeatureToggles()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://localhost/FeatureToggleAPI/");

            var endpoint = "api/Features?platform=Web";

            var myTask = client.GetAsync(endpoint);
            var response = myTask.Result;

            var result = new List<BaseFeatureToggle>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resultJson = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<BaseFeatureToggle>>(resultJson, new BaseFeatureConverter());
            }
            else
            {
                var responseMessage = response.Content.ReadAsStringAsync();
                ////log.ErrorFormat("Failed calling EncApi service endpoint: '{0}' with return code '{1}-{2}'\n\nDetails:\n\n{3}", endpointName, (int)response.StatusCode, response.StatusCode, responseMessage.Result);
            }

            return result;
        }
    }
}