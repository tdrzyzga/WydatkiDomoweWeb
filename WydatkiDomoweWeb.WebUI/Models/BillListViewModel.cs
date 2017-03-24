using WydatkiDomoweWeb.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class BillModel
    {
        public int Id { get; set; }
        public string BillName { get; set; }
        public string Recipient { get; set; }

        [UIHint("Decimal")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequiredDate { get; set; }
    }
    public class BillListViewModel
    {
        public IEnumerable<BillModel> Bills { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}