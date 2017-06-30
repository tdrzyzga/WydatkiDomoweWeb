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
    public class CrudRecipientsController : Controller
    {
        private IBillRepository billRepository;
        private IBillNameRepository billNameRepository;
        private IRecipientRepository recipientRepository;
        private IPostCodeRepository postcodeRepository;
        private ICityRepository cityRepository;
        private IStreetRepository streetRepository;

        public CrudRecipientsController(IBillRepository bill, IBillNameRepository billName, IRecipientRepository recipient, IPostCodeRepository postcode, ICityRepository city, IStreetRepository street)
        {
            this.billRepository = bill;
            this.billNameRepository = billName;
            this.recipientRepository = recipient;
            this.postcodeRepository = postcode;
            this.cityRepository = city;
            this.streetRepository = street;
        }

        [HttpGet]
        public PartialViewResult AddRecipient()
        {
            RecipientViewModel model = new RecipientViewModel();

            return PartialView(model);
        }

        [HttpPost]
        public RedirectToRouteResult AddRecipient(RecipientViewModel model)
        {
            if (ModelState.IsValid)
            {
                recipientRepository.Add(CreateRecipient(model));
                
                TempData["ChangedRecipient"] = string.Format("Zapisano nazwę rachunku: {0} ", model.Name.ToString());
            }

            return RedirectToAction("Index", "Recipients");
        }

        [HttpGet]
        public PartialViewResult EditRecipient(int recipientId)
        {
            var recipient = recipientRepository.Recipients.Single(r => r.RecipientID == recipientId);

            RecipientViewModel model = new RecipientViewModel
            {
                RecipientId = recipient.RecipientID,
                Name = recipient.Name,
                Account = recipient.Account,
                PostCode = postcodeRepository.PostCodes.Single(p => p.PostCodeID == recipient.PostCodeID).Name,
                City = cityRepository.Cities.Single(c => c.CityID == recipient.CityID).Name,
                Street = streetRepository.Streets.Single(s => s.StreetID == recipient.StreetID).Name,
                BuildingNr = recipient.BuildingNR
            };

            return PartialView(model);
        }

        [HttpPost]
        public RedirectToRouteResult EditRecipient(RecipientViewModel model)
        {
            if (ModelState.IsValid)
            {
                recipientRepository.Update(CreateRecipient(model));
                TempData["ChangedRecipient"] = string.Format("Zapisano zmiany u odbiorcy: {0} ", model.Name);
            }

            return RedirectToAction("Index", "Recipients");
        }

        [HttpGet]
        public PartialViewResult DeleteRecipient(int recipientId)
        {
            ItemDeleteViewModel model = new ItemDeleteViewModel
            {
                Bills = (from b in billRepository.Bills
                         join bn in billNameRepository.BillNames
                            on b.BillNameID equals bn.BillNameID
                         join r in recipientRepository.Recipients
                            on b.RecipientID equals r.RecipientID
                         where r.RecipientID == recipientId
                         select new BillViewModel
                         {
                             BillId = b.BillsID,
                             BillName = bn.Name,
                             Recipient = r.Name,
                             Amount = b.Amount,
                             PaymentDate = b.PaymentDate,
                             RequiredDate = b.RequiredDate
                         }).ToList(),
                Id = recipientId,
                Name = recipientRepository.Recipients.Single(r => r.RecipientID == recipientId).Name
            };

            return PartialView(model);
        }

        [HttpPost]
        public RedirectToRouteResult DeleteRecipient(ItemDeleteViewModel model)
        {
            if (model.Bills.Count() != 0)
            {
                foreach (var bill in model.Bills)
                    billRepository.Delete(bill.BillId);
            }

            recipientRepository.Delete(model.Id);
            TempData["ChangedRecipient"] = string.Format("Usunięto odbiorcę: {0} ", model.Name);

            return RedirectToAction("GetRecipients", "Recipients");
        }

        public JsonResult ValidateName(string name)
        {
            if (recipientRepository.ExistsName(name))
                return Json("Wybrana nazwa odbiorcy już istnieje w bazie danych", JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateAccount(string account)
        {
            if (recipientRepository.ExistsAccount(account))
                return Json("Wybrana konto już istnieje w bazie danych", JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }

        protected Recipient CreateRecipient(RecipientViewModel model)
        {
            Recipient recipient = new Recipient
            {
                RecipientID = model.RecipientId,
                Name = model.Name,
                Account = model.Account,
                PostCodeID = postcodeRepository.Exists(model.PostCode) ?? postcodeRepository.Add(model.PostCode),
                StreetID = streetRepository.Exists(model.Street) ?? streetRepository.Add(model.Street),
                CityID = cityRepository.Exists(model.City) ?? cityRepository.Add(model.City),
                BuildingNR = model.BuildingNr
            };

            return recipient;
        }
    }
}
