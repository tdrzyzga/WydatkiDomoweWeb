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
    public class BillController : Controller
    {
        private IBillRepository billRepository;
        private IBillNameRepository billNameRepository;
        private IRecipientRepository recipientRepository;

        public BillController(IBillRepository bill, IBillNameRepository billName, IRecipientRepository recipient)
        {
            this.billRepository = bill;
            this.billNameRepository = billName;
            this.recipientRepository = recipient;
        }

        [HttpGet]
        public PartialViewResult AddBill()
        {
            CreationBillViewModel model = new CreationBillViewModel
            {
                Bills = billNameRepository.BillNames.Select(bn => new SelectBillItem
                {
                    Name = bn.Name,
                    Id = bn.BillNameID.ToString(),
                    Date = SetDate(bn.FirstPaymentDate, bn.PaymentsFrequency, bn.BillNameID)

                }).ToList(),

                Recipients = recipientRepository.Recipients.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.RecipientID.ToString()
                }).ToList()
            };
            return PartialView(model);
        }

        [HttpPost]
        public RedirectToRouteResult AddBill(CreationBillViewModel model)
        {
            Bill bill = new Bill
            {
                BillNameID = model.SelectedBillId,
                RecipientID = model.SelectedRecipientId,
                Amount = model.Amount,
                PaymentDate = DateTime.ParseExact(model.PaymentDate, "dd.MM.yyyy HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture),
                RequiredDate = model.Bills.Single(b => b.Id == model.SelectedBillId.ToString()).Date
            };

            billRepository.SaveBill(bill);

            return RedirectToAction("Index", "Home");
        }


        public DateTime SetDate(DateTime firstPaymentDate, int paymentFerquency, int billNameId)
        {
            DateTime date;

            if (billRepository.Bills.Any(b => b.BillNameID == billNameId))
                date = billRepository.Bills.Last(b => b.BillNameID == billNameId).RequiredDate.AddDays(paymentFerquency);
            else
                date = firstPaymentDate.AddDays(paymentFerquency);
            return date;
        }
    }
}
