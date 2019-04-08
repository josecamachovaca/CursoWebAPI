using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Configuration
{
    public static class WebAPIConfig
    {
        public static void Register(HttpConfiguration cfg)
        {
            cfg.MapHttpAttributeRoutes();
            cfg.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id= RouteParameter.Optional}
                );
        }
    }
}