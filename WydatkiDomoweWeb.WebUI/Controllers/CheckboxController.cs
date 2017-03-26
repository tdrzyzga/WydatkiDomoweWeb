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
    public class CheckboxController : Controller
    {
        private IBillRepository repository;

        public CheckboxController(IBillRepository billRepository)
        {
            this.repository = billRepository;
        }

        [HttpGet]
        public PartialViewResult CheckboxList(CheckboxItems checkbox)
        {
            return PartialView(new CheckboxViewModel { Checkbox = checkbox });            
        }

        [HttpPost]
        public RedirectToRouteResult CheckboxList(CheckboxViewModel checkbox)
        {
            return RedirectToAction("List", "Bill");
        }

    }
}
