using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WydatkiDomoweWeb.Domain.Abstract;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class CheckboxModel
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }

    public class FilterBillViewModel
    {
        public List<CheckboxModel> CheckboxItems { get; set; }

        public FilterBillViewModel()
        {
            CheckboxItems = new List<CheckboxModel>();
        }
    }
}