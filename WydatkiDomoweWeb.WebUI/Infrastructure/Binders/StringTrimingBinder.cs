﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace WydatkiDomoweWeb.WebUI.Infrastructure.Binders
{
    public class StringTrimmingBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(controllerContext.HttpContext.Request.QueryString.AllKeys[0]);

            if (valueResult == null)
                return null;

            var stringValue = (string)valueResult.AttemptedValue;

            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                stringValue = regex.Replace(stringValue, " ");
                stringValue = stringValue.Trim();
            }

            return stringValue;
        }
    }
}
        