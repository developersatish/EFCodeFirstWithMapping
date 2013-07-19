using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
namespace EFCodeFirstWithMapping.Utilities
{
    public class RouteUrl
    {
        public static void RegisterRoute(RouteCollection route)
        {
            route.MapPageRoute("Home", "", "~/CodeFirstWithMapping.aspx");
            route.MapHttpRoute(name: "Default", routeTemplate: "api/{controller}/{id}",
                               defaults: new { id = RouteParameter.Optional });

        }
    }
}