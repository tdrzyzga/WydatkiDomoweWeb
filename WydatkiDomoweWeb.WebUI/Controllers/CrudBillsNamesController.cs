﻿using System;
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
                billNameRepository.Add(CreateBillName(model));
                TempData["ChangedBillName"] = string.Format("Zapisano nazwę rachunku: {0} ", model.Name.ToString());
            }

            return RedirectToAction("Index", "BillsNames");
        }

        [HttpGet]
        public PartialViewResult EditBillName(int billNameId)
        {
            BillName billName = billNameRepository.BillNames.Single(bn => bn.BillNameID == billNameId);

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
                billNameRepository.Update(CreateBillName(model));
                TempData["ChangedBillName"] = string.Format("Zapisano zmiany w nazwie rachunku: {0} ", model.Name);
            }

            return RedirectToAction("Index", "BillsNames");
        }

        [HttpGet]
        public PartialViewResult DeleteBillName(int billNameId)
        {
            ItemDeleteViewModel model = new ItemDeleteViewModel
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
                 Id = billNameId,
                 Name = billNameRepository.BillNames.Single(bn => bn.BillNameID == billNameId).Name
            };

            return PartialView(model);
        }

        [HttpPost]
        public RedirectToRouteResult DeleteBillName(ItemDeleteViewModel model)
        {
            if (model.Bills.Count() != 0)
            {
                foreach (var bill in model.Bills)
                    billRepository.Delete(bill.BillId);
            }

            billNameRepository.Delete(model.Id);
            TempData["ChangedBillName"] = string.Format("Usunięto nazwę rachunku: {0} ", model.Name);
            
            return RedirectToAction("GetBillsNames", "BillsNames");
        }

        public JsonResult ValidateName(string name, int BillNameId)
        {
            JsonResult result;

            if (billNameRepository.Exists(name))
            {
                int idByName = billNameRepository.BillNames.Single(bn => bn.Name.ToLower() == name.ToLower()).BillNameID;
                
                if (BillNameId != idByName)
                    result = Json("Wybrana nazwa rachunku już istnieje w bazie danych", JsonRequestBehavior.AllowGet);
                else
                    result = Json(true, JsonRequestBehavior.AllowGet);
            }
            else
                result = Json(true, JsonRequestBehavior.AllowGet);

            return result;
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
