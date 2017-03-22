﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.WebUI.Models;
using WydatkiDomoweWeb.WebUI.Models.Abstract;

namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class CheckboxController : Controller
    {
        private IBillRepository repository;
        private ICheckboxListViewModel model;

        public CheckboxController(IBillRepository billRepository, ICheckboxListViewModel checkbox)
        {
            this.repository = billRepository;
            this.model = checkbox;

            model.CheckboxItems = (from bn in repository.BillNames
                                   select new CheckboxModel
                                   {
                                       Name = bn.Name,
                                       IsChecked = true
                                   }).ToList();
        }

        public PartialViewResult CheckboxList()
        {         
            return PartialView(model);            
        }

    }
}
