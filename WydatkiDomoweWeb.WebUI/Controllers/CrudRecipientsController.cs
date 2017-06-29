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
        private IRecipientRepository recipientRepository;
        private IPostCodeRepository postcodeRepository;
        private ICityRepository cityRepository;
        private IStreetRepository streetRepository;

        public CrudRecipientsController(IRecipientRepository recipient, IPostCodeRepository postcode, ICityRepository city, IStreetRepository street)
        {
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

        public Recipient CreateRecipient(RecipientViewModel model)
        {
            Recipient recipient = new Recipient
            {
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
