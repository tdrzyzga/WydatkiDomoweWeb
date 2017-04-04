using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Filters
{
    public class BillFilter
    {
        public IEnumerable<BillModel> FilterBills(CheckboxViewModel checkbox, IEnumerable<BillModel> listBills)
        {
            List<BillModel> currentList = new List<BillModel>();

            if (checkbox.Items.Count() != 0)
            {
                for (int i = 0; i < checkbox.Items.Count(); i++)
                {
                    var query = listBills.Where(bn => bn.BillName == checkbox.Items[i].Name && checkbox.Items[i].IsChecked);
                    currentList.AddRange(query);
                }
            }
            else
            {
                currentList.AddRange(listBills);
            }

            return currentList;
        }
    }
}