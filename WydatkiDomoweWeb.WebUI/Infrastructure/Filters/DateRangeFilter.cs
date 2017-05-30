using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Infrastructure.Filters
{
    public static class DateRangeFilter
    {
        public static IEnumerable<BillModel> FilterByDateRange(this IEnumerable<BillModel> bills, FilterBillViewModel filterModel)
        {
            DateTime minDate;
            DateTime maxDate;
            List<BillModel> currentBills = new List<BillModel>();

            if (filterModel.MinDate != null && filterModel.MaxDate != null)
            {
                minDate = DateTime.ParseExact(filterModel.MinDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                maxDate = DateTime.ParseExact(filterModel.MaxDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);

                currentBills = bills.Where(b => b.PaymentDate >= minDate && b.PaymentDate <= maxDate).ToList();
                
            }
            else
            {
                currentBills.AddRange(bills);
            }

            return currentBills;
        }
    }
}