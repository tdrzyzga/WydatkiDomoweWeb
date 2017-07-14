using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Highsoft.Web.Mvc.Charts;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.WebUI.Infrastructure.Helpers
{
    public static class ChartHelpers
    {
        public static IEnumerable<ColumnSeries> CreateSeriesData(IEnumerable<Bill> bills)
        {
            int numberOFMonths = 12;
            List<int> years = bills.GroupBy(b => b.PaymentDate.Year).OrderBy(b => b.Key).Select(b => b.Key).ToList();
            List<Tuple<int, int, decimal>> dataFromRepository = (from b in bills
                                                                 group b by new
                                                                 {
                                                                     b.PaymentDate.Year,
                                                                     b.PaymentDate.Month
                                                                 } into g
                                                                 select new Tuple<int, int, decimal>(g.Key.Year, g.Key.Month, g.Sum(b => b.Amount)))
                                                                 .OrderBy(b => b.Item1)
                                                                 .ToList();

            List<Tuple<int, int, decimal>> seriesTemp = new List<Tuple<int, int, decimal>>();
            foreach (var year in years)
            {
                for (int b = 0; b < numberOFMonths; b++)
                {
                    seriesTemp.Add(new Tuple<int, int, decimal>(year, b, 0));
                }
            }

            foreach (var item in dataFromRepository)
            {
                int index = seriesTemp.IndexOf(new Tuple<int, int, decimal>(item.Item1, item.Item2, 0));
                seriesTemp[index - 1] = item;
            }

            IEnumerable<ColumnSeries> seriesData = years.Select(y => new ColumnSeries
            {
                Name = y.ToString(),
                Data = seriesTemp.Where(s => s.Item1 == y).Select(cs => new ColumnSeriesData
                {
                    Y = Decimal.ToDouble(cs.Item3)
                }).ToList()
            });

            return seriesData;
        }
    }
}