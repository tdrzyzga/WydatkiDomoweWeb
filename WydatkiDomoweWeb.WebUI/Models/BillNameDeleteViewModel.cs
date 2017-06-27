using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class BillNameDeleteViewModel
    {
        public int BillNameId { get; set; }
        public List<BillViewModel> Bills { get; set; }

        public BillNameDeleteViewModel()
        {
            Bills = new List<BillViewModel>();
        }
    }
}