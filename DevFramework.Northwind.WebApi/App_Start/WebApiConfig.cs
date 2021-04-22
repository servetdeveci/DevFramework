using DevFramework.Northwind.WebApi.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DevFramework.Northwind.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // AuthorizationHandler ile direkt manager dan geçmesi ile deil arada author olup ole gecmesini sağlıyoruz
            config.MessageHandlers.Add(new AuthenticationHandler());


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
