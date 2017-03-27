using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.WebUI.Models;


namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class CheckboxBillsController : Controller
    {
        private IBillRepository repository;
        private List<CheckboxModel> checkboxList;

        public CheckboxBillsController(CheckboxViewModel checkbox, IBillRepository billRepisotory)
        {
            this.repository = billRepisotory;

            checkboxList = (from bn in repository.BillNames
                             select new CheckboxModel
                             {
                                 Name = bn.Name,
                                 IsChecked = true
                             }).ToList();
        }

        [HttpGet]
        public PartialViewResult Items(CheckboxViewModel checkbox)
        {
            if (checkbox.Items.Count() == 0)
                checkbox.Items = checkboxList;

            return PartialView(checkbox.Items);            
        }

        [HttpPost]
        public RedirectToRouteResult Items(CheckboxViewModel checkbox, List<CheckboxModel> model)
        {
            checkbox.Items = model;
            return RedirectToAction("List", "Bill");
        }

    }
}
