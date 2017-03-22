using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.WebUI.Models.Abstract;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class CheckboxModel
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }

    public class CheckboxListViewModel : ICheckboxListViewModel
    {
        public List<CheckboxModel> CheckboxItems { get; set;}
    }
}