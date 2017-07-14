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
        public PartialViewResult MonthChart()
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
        public PartialViewResult YearChart()
        {
            List<string> category = billNameRepository.BillNames.GroupBy(bn => bn.BillNameID).OrderBy(bn => bn.Key).Select(bn => bn.Key.ToString()).ToList();

            IEnumerable<ColumnSeries> seriesData = billRepository.Bills.GroupBy(b => b.PaymentDate.Year).OrderBy(b => b.Key).Select(cs => new ColumnSeries
            {
                Name = cs.Key.ToString(),
                Data = cs.GroupBy(b => b.BillNameID).OrderBy(b => b.Key).Select(b => new ColumnSeriesData
                {
                    Y = b.Sum(sm => Decimal.ToDouble(sm.Amount))
                }).ToList()
            });
                
                /*).OrderBy(b => b.Key).Select(cs => new ColumnSeries
            {
                Name = cs.Key.ToString(),
                Data = cs.GroupBy(b => b.BillNameID).OrderBy(b => b.Key).Select(b => new ColumnSeriesData                       
                       {
                           Y = b. Sum(sm => Decimal.ToDouble(sm.Amount))
                       }).ToList()
            });*/

            Highcharts model = new Highcharts();
            //model.Chart = new Chart { Width = 1087, Height = 400, Type = ChartType.Column };
            model.Title = new Title { Text = "Zestawienie roczne" };
            model.XAxis = new List<XAxis> { new XAxis { Categories = category } };
            model.Series = new List<Series>(seriesData);

            return PartialView(model);
        }
    }
}
