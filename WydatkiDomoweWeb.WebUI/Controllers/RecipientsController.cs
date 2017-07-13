using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class RecipientsController : Controller
    {
        private IRecipientRepository recipientRepository;
        private IPostCodeRepository postcodeRepository;
        private ICityRepository cityRepository;
        private IStreetRepository streetRepository;

        public int PageSize = 10;

        public RecipientsController(IRecipientRepository recipient, IPostCodeRepository postCode, ICityRepository city, IStreetRepository street)
        {
            this.recipientRepository = recipient;
            this.postcodeRepository = postCode;
            this.cityRepository = city;
            this.streetRepository = street;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetRecipients(int page = 1)
        {
            IEnumerable<RecipientViewModel> recipients = from r in recipientRepository.Recipients
                             join p in postcodeRepository.PostCodes
                                on r.PostCodeID equals p.PostCodeID
                             join c in cityRepository.Cities
                                on r.CityID equals c.CityID
                             join s in streetRepository.Streets
                                on r.StreetID equals s.StreetID
                             select new RecipientViewModel
                             {
                                 RecipientId = r.RecipientID,
                                 Name = r.Name,
                                 Account = r.Account,
                                 PostCode = p.Name,
                                 City = c.Name,
                                 Street = s.Name,
                                 BuildingNr = r.BuildingNR
                             };

            RecipientsViewModel model = new RecipientsViewModel
            {
                Recipients = recipients.OrderByDescending(r => r.Name).Skip((page - 1) * PageSize).Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = recipients.Count()
                }
            };

            return PartialView(model);
        }

    }
}
