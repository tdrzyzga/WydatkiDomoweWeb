using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class EditBillViewModel
    {
        public int BillId { get; set; }
        public string BillName { get; set; }
        public int SelectedRecipientId { get; set; }

        [Required(ErrorMessage = "Proszę podać kwotę")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Proszę podać datę")]
        public string PaymentDate { get; set; }

        public string RequiredDate { get; set; }

        public List<SelectListItem> Recipients { get; set; }
    }
}