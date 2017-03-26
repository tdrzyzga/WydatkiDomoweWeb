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

    public class CheckboxItems
    {
        public List<CheckboxModel> Items { get; set; }

        public CheckboxItems() { }

        public CheckboxItems(IBillRepository repository)
        {
            Items = (from bn in repository.BillNames
                     select new CheckboxModel
                     {
                         Name = bn.Name,
                         IsChecked = true
                     }).ToList();
        }
    }

    public class CheckboxViewModel
    {
        public CheckboxItems Checkbox { get; set;}
    }
}