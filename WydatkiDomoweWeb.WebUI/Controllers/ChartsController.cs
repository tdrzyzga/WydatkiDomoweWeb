using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;
using Highsoft.Web.Mvc.Charts;
using WydatkiDomoweWeb.WebUI.Models;
using WydatkiDomoweWeb.WebUI.Infrastructure.Helpers;

namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class ChartsController : Controller
    {
        private IBillRepository billRepository;
        private IBillNameRepository billNameRepository;
        private IRecipientRepository recipientRepository;

        public int PageSize = 10;

        public ChartsController(IBillRepository bill, IBillNameRepository billName, IRecipientRepository recipient)
        {
            this.billRepository = bill;
            this.billNameRepository = billName;
            this.recipientRepository = recipient;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetMonthlyChart()
        {
            List<string> category = new List<string> { "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień" };
 
            ChartViewModel model = new ChartViewModel
            {
                Category = category,
                SeriesData = ChartHelpers.CreateSeriesData(billRepository.Bills)
            };

            return PartialView(model);
        }

        [HttpGet]
        public PartialViewResult GetYearlyChart()
        {
            List<string> category = billNameRepository.BillNames.OrderBy(bn => bn.Name).Select(bn => bn.Name).ToList();

            ChartViewModel model = new ChartViewModel
            {
                Category = category,
                SeriesData = ChartHelpers.CreateSeriesData(billRepository.Bills, billNameRepository.BillNames)
            };

            return PartialView(model);
        }
    }
}
