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

    public class CheckboxViewModel
    {
        public List<CheckboxModel> Items { get; set; }

        public CheckboxViewModel()
        {
            Items = new List<CheckboxModel>();
        }
    }
}