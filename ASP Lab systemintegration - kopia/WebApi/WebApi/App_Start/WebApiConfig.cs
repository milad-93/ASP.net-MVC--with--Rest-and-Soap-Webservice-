using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // add to not get cyclic refrence errors in json!!!

    config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = 
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;

    config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = 
                Newtonsoft.Json.PreserveReferencesHandling.None;



            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
