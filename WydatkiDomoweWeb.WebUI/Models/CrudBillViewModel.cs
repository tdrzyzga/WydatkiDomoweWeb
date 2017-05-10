using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class SelectBill
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime Date { get; set; }
    }

    public class CrudBillViewModel
    {
        public int BillId { get; set; }

        public int SelectedBillNameId { get; set; }
        public string BillName { get; set; }    

        public int SelectedRecipientId { get; set; }

        [Required(ErrorMessage = "Proszę podać kwotę")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Proszę podać datę")]
        public string PaymentDate { get; set; }

        public string RequiredDate { get; set; }

        public List<SelectListItem> Recipients { get; set; }
        public List<SelectBill> Bills { get; set; }

        public CrudBillViewModel()
        {
            Bills = new List<SelectBill>();
        }
    }
}