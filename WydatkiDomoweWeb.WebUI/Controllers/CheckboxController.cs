using System;
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

        [HttpGet]
        public PartialViewResult CheckboxList()
        {
            if (((List<CheckboxModel>)TempData["ListToCheckbox"]).Count() != 0)
            {
                List<CheckboxModel> checkboxList = (List<CheckboxModel>)TempData["ListToCheckbox"];
                model.CheckboxItems = checkboxList;
            }

            return PartialView(model);            
        }

        [HttpPost]
        public RedirectToRouteResult CheckboxList(CheckboxListViewModel checkbox)
        {
            model = checkbox;
            TempData["List"] = checkbox.CheckboxItems;
            return RedirectToAction("List", "Bill");
        }

    }
}
