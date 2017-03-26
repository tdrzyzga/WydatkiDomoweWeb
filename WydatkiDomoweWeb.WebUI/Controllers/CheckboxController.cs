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

        [HttpGet]
        public PartialViewResult CheckboxList(CheckboxItems checkbox)
        {
            return PartialView(checkbox.Items);            
        }

        [HttpPost]
        public RedirectToRouteResult CheckboxList(CheckboxItems checkbox, List<CheckboxModel> model)
        {
            checkbox.Items = model;
            return RedirectToAction("List", "Bill");
        }

    }
}
