using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;
using Highsoft.Web.Mvc.Charts;

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
        public PartialViewResult YearChart()
        {
            List<string> category = billRepository.Bills.GroupBy(b => b.PaymentDate.Month).Select(c => System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(c.Key)).ToList();
            
            IEnumerable<ColumnSeries> seriesData = billRepository.Bills.GroupBy(b => b.PaymentDate.Year).Select(cs => new ColumnSeries
            {
                Name = cs.Key.ToString(),
                Data = cs.GroupBy(g => g.PaymentDate.Month).Select(csd => new ColumnSeriesData
                {
                    Y = csd.Sum(a => Decimal.ToDouble(a.Amount)),
                }).ToList()
            });

            Highcharts model = new Highcharts();
            //model.Chart = new Chart { Width = 1087, Height = 400, Type = ChartType.Column };
            model.Title = new Title { Text = "Zestawienie miesięczne" };
            model.XAxis = new List<XAxis> { new XAxis { Categories = category } };
            model.Series = new List<Series>(seriesData);

            return PartialView(model);
        }

        [HttpGet]
        public PartialViewResult MonthChart()
        {
           List<string> category = (from b in billRepository.Bills
                         join bn in billNameRepository.BillNames
                            on b.BillNameID equals bn.BillNameID
                         select bn.Name).ToList();
            
            IEnumerable<ColumnSeries> seriesData = billRepository.Bills.GroupBy(b => b.PaymentDate.Year).Select(cs => new ColumnSeries
            {
                Name = cs.Key.ToString(),
                Data = cs.GroupBy(g => g.BillNameID).Select(csd => new ColumnSeriesData
                {
                    Y = csd.Sum(a => Decimal.ToDouble(a.Amount)),
                }).ToList()
            });

            Highcharts model = new Highcharts();
            //model.Chart = new Chart { Width = 1087, Height = 400, Type = ChartType.Column };
            model.Title = new Title { Text = "Zestawienie roczne" };
            model.XAxis = new List<XAxis> { new XAxis { Categories = category } };
            model.Series = new List<Series>(seriesData);

            return PartialView(model);
        }

    }
}
