using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class CreationBillViewModel
    {
        public int SelectedBillId { get; set; }
        public int SelectedRecipientId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime RequiredDate { get; set; }

        public IEnumerable<SelectListItem> Bills { get; set; }
        public IEnumerable<SelectListItem> Recipients { get; set; }
    }
}