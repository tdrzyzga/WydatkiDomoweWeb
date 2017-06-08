using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.WebUI.Models;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class CrudBillsNamesController : Controller
    {
        private IBillNameRepository billNameRepository;

        public CrudBillsNamesController(IBillNameRepository billName)
        {
            this.billNameRepository = billName;
        }

        [HttpGet]
        public PartialViewResult AddBillName()
        {
            CrudBillsNamesViewModel model = new CrudBillsNamesViewModel();

            return PartialView(model);
        }

        [HttpPost]
        public RedirectToRouteResult AddBillName(CrudBillsNamesViewModel model)
        {
            if (ModelState.IsValid)
                billNameRepository.AddBillName(CreateBillName(model));

            TempData["ChangedBillName"] = string.Format("Zapisano nazwę rachunku: {0} ", model.Name.ToString());
            return RedirectToAction("Index", "BillsNames");
        }

        public JsonResult ValidateName(string name)
        {
            if (billNameRepository.Exists(name))
                return Json("Wybrana nazwa już istnieje w bazie danych", JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }

        protected BillName CreateBillName(CrudBillsNamesViewModel model)
        {
            BillName billName = new BillName
            {
                BillNameID = model.BillNameId,
                Name = model.Name,
                FirstPaymentDate = DateTime.ParseExact(model.FirstPaymentDate, "dd.MM.yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture),
                PaymentsFrequency = model.PaymentsFerquency
            };

            return billName;
        }
    }
}
