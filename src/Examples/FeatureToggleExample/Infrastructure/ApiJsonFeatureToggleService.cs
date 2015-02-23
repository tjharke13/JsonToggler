using JsonToggler;
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
    //Use JsonToggler.Api project.
    //public class ApiJsonFeatureToggleService
    //{
    //    private List<IFeatureToggle> _featureToggles;

    //    public ApiJsonFeatureToggleService()
    //    {
    //        _featureToggles = this.GetFeatureToggles();
    //        if (_featureToggles == null)
    //        {
    //            _featureToggles = new List<IFeatureToggle>();
    //        }
    //    }

    //    public T GetFeatureToggle<T>() where T : FeatureToggle, new()
    //    {
    //        string name = typeof(T).Name;

    //        var feature = _featureToggles.Where(w => w.GetType() == typeof(T)).FirstOrDefault();

    //        if (feature == null)
    //            feature = new T() { Name = name.Replace("_", " ") };

    //        return (T)feature;
    //    }

    //    public List<IFeatureToggle> GetFeatureToggles()
    //    {
    //        var client = new HttpClient();
    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        client.BaseAddress = new Uri("http://localhost/FeatureToggleAPI/");

    //        var endpoint = "api/ComplexFeatures?platform=Web";

    //        var myTask = client.GetAsync(endpoint);
    //        var response = myTask.Result;

    //        var result = new List<IFeatureToggle>();
    //        if (response.StatusCode == HttpStatusCode.OK)
    //        {
    //            var resultJson = response.Content.ReadAsStringAsync().Result;
    //            result = JsonConvert.DeserializeObject<List<IFeatureToggle>>(resultJson, new FeatureConverter("FeatureToggleExample", "FeatureToggleExample.FeatureToggles.ApiJsonToggler"));
    //        }
    //        else
    //        {
    //            var responseMessage = response.Content.ReadAsStringAsync();
    //            ////log.ErrorFormat("Failed calling EncApi service endpoint: '{0}' with return code '{1}-{2}'\n\nDetails:\n\n{3}", endpointName, (int)response.StatusCode, response.StatusCode, responseMessage.Result);
    //        }

    //        return result;
    //    }
    //}
}