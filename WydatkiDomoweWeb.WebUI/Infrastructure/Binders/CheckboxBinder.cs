using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Concrete;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Infrastructure.Binders
{
    public class CheckboxBinder : IModelBinder
    {
        private const string sessionKey = "Checkbox";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            CheckboxViewModel checkboxItems = null;
            if (controllerContext.HttpContext.Session != null)
            {
                checkboxItems = (CheckboxViewModel)controllerContext.HttpContext.Session[sessionKey];
            }

            if (checkboxItems == null)
            {
                checkboxItems = new CheckboxViewModel();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = checkboxItems;
                }
            }

            return checkboxItems;
        }
    }
}