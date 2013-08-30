using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Places
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "PlacesApi",
                routeTemplate: "api/places/{action}",
                defaults: new { controller = "places" }
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
