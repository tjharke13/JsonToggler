using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FeatureToggle.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.MapHttpAttributeRoutes();

            //Route to take in Actions also.
            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Remove XML formatter as we only want to handle JSON
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
