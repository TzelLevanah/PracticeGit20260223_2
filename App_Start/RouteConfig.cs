using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AbandonLogger
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // วาง route แบบเฉพาะก่อน
            routes.MapRoute(
                name: "AbandonLog",
                url: "abandon-log",
                defaults: new { controller = "AbandonLog", action = "Receive" }
            );

            // Default route ต้องวางไว้ท้ายสุด
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

}
