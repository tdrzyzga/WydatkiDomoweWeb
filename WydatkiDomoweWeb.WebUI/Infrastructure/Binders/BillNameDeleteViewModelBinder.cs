﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Infrastructure.Binders
{
    public class BillNameDeleteViewModelBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            BillNameDeleteViewModel modelBillsToRemove = new BillNameDeleteViewModel();
            modelBillsToRemove.BillNameId = Int32.Parse(controllerContext.HttpContext.Request.Form["BillNameId"]);
            modelBillsToRemove.Name = controllerContext.HttpContext.Request.Form["Name"];

            string[] idBillsToRemove = controllerContext.HttpContext.Request.Form.AllKeys;
            idBillsToRemove = idBillsToRemove.Take(idBillsToRemove.Count() - 3).ToArray();

            for (int i = 0; i < idBillsToRemove.Count(); i++)
            {
                BillViewModel billViewModel = new BillViewModel
                {
                    BillId = Int32.Parse(bindingContext.ValueProvider.GetValue(idBillsToRemove[i]).AttemptedValue)
                };

                modelBillsToRemove.Bills.Add(billViewModel);
            }

            return modelBillsToRemove;
        }
    }
}