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
            bundles.Add(new ScriptBundle("~/bundles/webScripts")
                .Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/moment-with-locales.js",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/bootstrap-datetimepicker.min.js",
                    "~/Scripts/jquery.unobtrusive-ajax.min.js",
                    "~/Scripts/configureCheckbox.js",
                    "~/Scripts/crud.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/validation")
                .Include(
                    "~/Scripts/jqueryFix.js",
                    "~/Scripts/jquery.validate.min.js",
                    "~/Scripts/jquery.validate.unobtrusive.min.js"                
               ));
        }
    } 
}