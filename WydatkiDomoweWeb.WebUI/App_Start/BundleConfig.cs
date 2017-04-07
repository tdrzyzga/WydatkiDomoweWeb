using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WydatkiDomoweWeb.WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/*.css"));
            bundles.Add(new ScriptBundle("~/bundles/webscripts")
                .Include(
                 "~/Scripts/jquery-{version}.js",
                "~/Scripts/moment-with-locales.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootstrap-datetimepicker.min.js"
               ));
        }
    } 
}