using WydatkiDomoweWeb.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class BillModel
    {
        public int Id { get; set; }
        public string BillName { get; set; }
        public string Recipient { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime RequiredDate { get; set; }
    }
    public class BillListViewModel
    {
        public IEnumerable<BillModel> Bills { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}