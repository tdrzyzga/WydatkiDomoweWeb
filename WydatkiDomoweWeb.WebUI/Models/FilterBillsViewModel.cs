using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WydatkiDomoweWeb.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class CheckboxModel
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }

        public CheckboxModel() { }
    }

    public class FilterBillsViewModel
    {
        public List<CheckboxModel> CheckboxItems { get; set; }

        [Required(ErrorMessage = "Proszę podać datę")]
        public string MinDate { get; set; }

        [Required(ErrorMessage = "Proszę podać datę")]
        public string MaxDate { get; set; }

        public FilterBillsViewModel()
        {
            CheckboxItems = new List<CheckboxModel>();
        }
    }
}