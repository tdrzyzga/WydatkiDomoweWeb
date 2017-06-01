using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class BillNameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FirstPaymentDate { get; set; }

        public int PaymentsFerquency { get; set; }
    }

    public class BillsNamesViewModel
    {
        public IEnumerable<BillNameModel> BillsNames { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}