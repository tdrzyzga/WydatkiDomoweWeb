using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class ItemDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BillViewModel> Bills { get; set; }

        public ItemDeleteViewModel()
        {
            Bills = new List<BillViewModel>();
        }
    }
}