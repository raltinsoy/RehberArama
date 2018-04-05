using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RehberArama
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Rehberler",
                url: "{controller}/{action}/{isim}/{key}",
                defaults: new { controller = "Rehberler", action = "SorguKategori", isim = UrlParameter.Optional, key = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Yonet",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Yonet", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{ara}",
                defaults: new { controller = "Search", action = "Index", ara = UrlParameter.Optional }
            );
        }
    }
}
