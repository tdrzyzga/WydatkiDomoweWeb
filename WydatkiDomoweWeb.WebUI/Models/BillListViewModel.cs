using WydatkiDomoweWeb.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class BillView
    {
        public int Id { get; set; }
        public string BillName { get; set; }
        public string Recipient { get; set; }
        public decimal Amount { get; set; }
    }
    public class BillListViewModel
    {
        public IEnumerable<BillView> Bills { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}