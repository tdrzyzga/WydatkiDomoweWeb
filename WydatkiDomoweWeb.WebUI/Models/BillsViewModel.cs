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

        [DisplayFormat(DataFormatString = "{0:c2}")]
        public decimal Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime RequiredDate { get; set; }
    }

    public class BillsViewModel
    {
        public IEnumerable<BillModel> Bills { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}