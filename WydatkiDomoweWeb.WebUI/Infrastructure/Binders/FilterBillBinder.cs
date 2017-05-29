using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Concrete;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Infrastructure.Binders
{
    public class FilterBillBinder : IModelBinder
    {
        private const string sessionKey = "Checkbox";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            FilterBillViewModel filterModel = null;
            if (controllerContext.HttpContext.Session != null)
            {
                filterModel = (FilterBillViewModel)controllerContext.HttpContext.Session[sessionKey];
            }

            if (filterModel == null)
            {
                filterModel = new FilterBillViewModel();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = filterModel;
                }
            }

            if (bindingContext.ModelName == "filterPostModel")
            {
                string[] checkboxLabelName;
                List<string> checkboxLabelValue = new List<string>();

                checkboxLabelName = controllerContext.HttpContext.Request.Form.AllKeys;

                for (int i = 0; i < checkboxLabelName.Count(); i++)
                {
                    if (checkboxLabelName[i] == "MinDate" || checkboxLabelName[i] == "MaxDate")
                        break;
                    checkboxLabelValue.Add(bindingContext.ValueProvider.GetValue(checkboxLabelName[i++]).AttemptedValue.Split(',')[0]);
                }
                for (int i=0; i<filterModel.CheckboxItems.Count(); i++)
                    filterModel.CheckboxItems[i].IsChecked = checkboxLabelValue[i] == "true" ? true : false;

            }          

            return filterModel;
        }
    }
}