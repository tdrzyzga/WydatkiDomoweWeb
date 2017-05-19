﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{page}",
                defaults: new { controller = "Home", action = "Index", page = 1 }
           );
        }
    }
}
