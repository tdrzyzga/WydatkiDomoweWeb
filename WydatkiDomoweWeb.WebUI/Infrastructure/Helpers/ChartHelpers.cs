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

        public static IEnumerable<ColumnSeries> CreateSeriesData(IEnumerable<Bill> bills, IEnumerable<BillName> billsNames)
        {
            List<int> years = bills.GroupBy(b => b.PaymentDate.Year).OrderBy(b => b.Key).Select(b => b.Key).ToList();
            List<string> names = billsNames.OrderBy(bn => bn.Name).Select(bn => bn.Name).ToList();
            List<Tuple<int, string, decimal>> dataFromRepository = (from b in bills
                                                                    join bn in billsNames
                                                                        on b.BillNameID equals bn.BillNameID
                                                                 group b by new
                                                                 {
                                                                     b.PaymentDate.Year,
                                                                     bn.Name
                                                                 } into g
                                                                 select new Tuple<int, string, decimal>(g.Key.Year, g.Key.Name, g.Sum(b => b.Amount)))
                                                                 .OrderBy(b => b.Item1).ThenBy(bn => bn.Item2)
                                                                 .ToList();

            List<Tuple<int, string, decimal>> seriesTemp = new List<Tuple<int, string, decimal>>();
            foreach (var year in years)
            {
                foreach(var name in names)
                {
                    seriesTemp.Add(new Tuple<int, string, decimal>(year, name, 0));
                }
            }

            foreach (var item in dataFromRepository)
            {
                int index = seriesTemp.IndexOf(new Tuple<int, string, decimal>(item.Item1, item.Item2, 0));
                seriesTemp[index] = item;
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

        public static IEnumerable<ColumnSeries> CreateSeriesData(IEnumerable<Bill> bills, int id)
        {
            int numberOFMonths = 12;
            List<int> years = bills.GroupBy(b => b.PaymentDate.Year).OrderBy(b => b.Key).Select(b => b.Key).ToList();
            List<Tuple<int, int, decimal>> dataFromRepository = (from b in bills
                                                                 where b.BillNameID == id
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