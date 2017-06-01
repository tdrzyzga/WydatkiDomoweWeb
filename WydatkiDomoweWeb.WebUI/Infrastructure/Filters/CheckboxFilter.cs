using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Infrastructure.Filters
{
    public static class CheckboxFilter
    {
        public static IEnumerable<BillModel> FilterByCheckbox(this IEnumerable<BillModel> bills, FilterBillsViewModel filterModel)
        {
            List<BillModel> currentBills = new List<BillModel>();

            if (filterModel.CheckboxItems.Count() != 0)
            {
                for (int i = 0; i < filterModel.CheckboxItems.Count(); i++)
                {
                    var query = bills.Where(bn => bn.BillName.Equals(filterModel.CheckboxItems[i].Name) && filterModel.CheckboxItems[i].IsChecked);
                    currentBills.AddRange(query);
                }
            }
            else
            {
                currentBills.AddRange(bills);
            }

            return currentBills;
        }
    }
}