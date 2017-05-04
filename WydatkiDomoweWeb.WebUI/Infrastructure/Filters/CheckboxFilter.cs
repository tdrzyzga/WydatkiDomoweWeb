using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Infrastructure.Filters
{
    public static class CheckboxFilter
    {
        public static IEnumerable<BillModel> Filter(this IEnumerable<BillModel> bills, CheckboxViewModel checkbox)
        {
            List<BillModel> currentBills = new List<BillModel>();

            if (checkbox.Items.Count() != 0)
            {
                for (int i = 0; i < checkbox.Items.Count(); i++)
                {
                    var query = bills.Where(bn => bn.BillName.Equals(checkbox.Items[i].Name) && checkbox.Items[i].IsChecked);
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