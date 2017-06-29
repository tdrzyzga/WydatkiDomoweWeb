using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.WebUI.Models;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class CrudBillsController : Controller
    {
        private IBillRepository billRepository;
        private IBillNameRepository billNameRepository;
        private IRecipientRepository recipientRepository;

        public CrudBillsController(IBillRepository bill, IBillNameRepository billName, IRecipientRepository recipient)
        {
            this.billRepository = bill;
            this.billNameRepository = billName;
            this.recipientRepository = recipient;
        }

        [HttpGet]
        public PartialViewResult AddBill()
        {
            CrudBillsViewModel model = new CrudBillsViewModel
            {
                Bills = billNameRepository.BillNames.Select(bn => new SelectBillName
                {
                    BillNameId = bn.BillNameID.ToString(),
                    Name = bn.Name,                    
                    RequiredDate = SetRequiredDate(bn.FirstPaymentDate, bn.PaymentsFrequency, bn.BillNameID)

                }).ToList(),

                Recipients = recipientRepository.Recipients.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.RecipientID.ToString()
                }).ToList()
            };

            return PartialView(model);
        }

        protected DateTime SetRequiredDate(DateTime firstPaymentDate, int paymentFerquency, int billNameId)
        {
            DateTime date;

            if (billRepository.Bills.Any(b => b.BillNameID == billNameId))
                date = billRepository.Bills.Last(b => b.BillNameID == billNameId).RequiredDate.AddDays(paymentFerquency);
            else
                date = firstPaymentDate;

            return date;
        }

        [HttpPost]
        public RedirectToRouteResult AddBill(CrudBillsViewModel model)
        {
            if (ModelState.IsValid)
            {
                billRepository.Add(CreateBill(model));
                TempData["ChangedBill"] = string.Format("Zapisano rachunek: {0} ", model.Bills.Single(b => b.BillNameId == model.SelectedBillNameId.ToString()).Name);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public PartialViewResult EditBill(int billId)
        {
            var billNameId = billRepository.Bills.Single(b => b.BillsID == billId).BillNameID;

            CrudBillsViewModel model = new CrudBillsViewModel
            {                
                BillId = billId,
                SelectedBillNameId = billNameId,
                BillName = billNameRepository.BillNames.Single(bn => bn.BillNameID == billNameId).Name,
                Amount = billRepository.Bills.Single(b => b.BillsID == billId).Amount,
                PaymentDate = billRepository.Bills.Single(b => b.BillsID == billId).PaymentDate.ToString("dd.MM.yyyy"),
                RequiredDate = billRepository.Bills.Single(b => b.BillsID == billId).RequiredDate.ToString("dd.MM.yyyy"),
                Recipients = recipientRepository.Recipients.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.RecipientID.ToString()
                }).ToList()
            };

            return PartialView(model);
        }

        [HttpPost]
        public RedirectToRouteResult EditBill(CrudBillsViewModel model)
        {
            if (ModelState.IsValid)
            {
                billRepository.Update(CreateBill(model));
                TempData["ChangedBill"] = string.Format("Zapisano zmiany w rachunku: {0} ", model.BillName);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public RedirectToRouteResult DeleteBill(int billId, string billName)
        {
            billRepository.Delete(billId);
            TempData["ChangedBill"] = string.Format("Usunięto rachunek: {0} ", billName);

            return RedirectToAction("GetBills", "Home");
        }

        protected Bill CreateBill(CrudBillsViewModel model)
        {
            Bill bill = new Bill
            {
                BillsID = model.BillId,
                BillNameID = model.SelectedBillNameId,
                RecipientID = model.SelectedRecipientId,
                Amount = model.Amount,
                PaymentDate = DateTime.ParseExact(model.PaymentDate, "dd.MM.yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture),
                RequiredDate = DateTime.ParseExact(model.RequiredDate, "dd.MM.yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture),
            };

            return bill;
        }
    }
}
