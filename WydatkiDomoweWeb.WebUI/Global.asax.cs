using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WydatkiDomoweWeb.WebUI.Infrastructure.Binders;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(FilterBillsViewModel), new FilterBillBinder());
            ModelBinders.Binders.DefaultBinder = new StringTrimmingBinder();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
