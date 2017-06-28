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
        private IBillRepository billRepository;
        private IBillNameRepository billNameRepository;
        private IRecipientRepository recipientRepository;

        public CrudBillsNamesController(IBillRepository bill, IBillNameRepository billName, IRecipientRepository recipient)
        {
            this.billRepository = bill;
            this.billNameRepository = billName;
            this.recipientRepository = recipient;
        }

        [HttpGet]
        public PartialViewResult AddBillName()
        {
            BillNameViewModel model = new BillNameViewModel();

            return PartialView(model);
        }

        [HttpPost]
        public RedirectToRouteResult AddBillName(BillNameViewModel model)
        {
            if (ModelState.IsValid)
            {
                billNameRepository.AddBillName(CreateBillName(model));
                TempData["ChangedBillName"] = string.Format("Zapisano nazwę rachunku: {0} ", model.Name.ToString());
            }

            return RedirectToAction("Index", "BillsNames");
        }

        [HttpGet]
        public PartialViewResult EditBillName(int billNameId)
        {
            var billName = billNameRepository.BillNames.Single(bn => bn.BillNameID == billNameId);

            BillNameViewModel model = new BillNameViewModel
            {
                BillNameId = billNameId,
                Name = billName.Name,
                FirstPaymentDate = billName.FirstPaymentDate.ToString("dd.MM.yyyy"),
                PaymentsFerquency = billName.PaymentsFrequency
            };

            return PartialView(model);
        }

        [HttpPost]
        public RedirectToRouteResult EditBillName(BillNameViewModel model)
        {
            if (ModelState.IsValid)
            {
                billNameRepository.UpdateBillName(CreateBillName(model));
                TempData["ChangedBillName"] = string.Format("Zapisano zmiany w nazwie rachunku: {0} ", model.Name);
            }

            return RedirectToAction("Index", "BillsNames");
        }
        [HttpGet]
        public PartialViewResult DeleteBillName(int billNameId)
        {
            BillNameDeleteViewModel model = new BillNameDeleteViewModel
            {
                Bills = (from b in billRepository.Bills
                         join bn in billNameRepository.BillNames
                            on b.BillNameID equals bn.BillNameID
                         join r in recipientRepository.Recipients
                            on b.RecipientID equals r.RecipientID
                         where b.BillNameID == billNameId
                         select new BillViewModel
                         {
                             BillId = b.BillsID,
                             BillName = bn.Name,
                             Recipient = r.Name,
                             Amount = b.Amount,
                             PaymentDate = b.PaymentDate,
                             RequiredDate = b.RequiredDate
                         }).ToList(),
                 BillNameId = billNameId,
                 Name = billNameRepository.BillNames.Single(bn => bn.BillNameID == billNameId).Name
            };

            return PartialView(model);
        }

        [HttpPost]
        public RedirectToRouteResult DeleteBillName(BillNameDeleteViewModel model)
        {
            if (model.Bills.Count() != 0)
            {
                foreach (var bill in model.Bills)
                    billRepository.DeleteBill(bill.BillId);
            }

            billNameRepository.DeleteBillName(model.BillNameId);
            TempData["ChangedBillName"] = string.Format("Usunięto nazwę rachunku: {0} ", model.Name);
            
            return RedirectToAction("GetBillsNames", "BillsNames");
        }

        public JsonResult ValidateName(string name)
        {
            if (billNameRepository.Exists(name))
                return Json("Wybrana nazwa już istnieje w bazie danych", JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }

        protected BillName CreateBillName(BillNameViewModel model)
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
