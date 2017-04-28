using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Infrastructure.Filters
{
    public class CheckboxFilter
    {
        public CheckboxViewModel Checkbox { get; set; }

        public CheckboxFilter(CheckboxViewModel model)
        {
            Checkbox = model;
        }

        public IEnumerable<BillModel> Filter(IEnumerable<BillModel> bills)
        {
            List<BillModel> currentBills = new List<BillModel>();

            if (Checkbox.Items.Count() != 0)
            {
                for (int i = 0; i < Checkbox.Items.Count(); i++)
                {
                    var query = bills.Where(bn => bn.BillName.Equals(Checkbox.Items[i].Name) && Checkbox.Items[i].IsChecked);
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