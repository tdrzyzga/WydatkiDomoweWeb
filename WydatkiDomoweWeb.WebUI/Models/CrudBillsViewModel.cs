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

    public class CrudBillsViewModel
    {
        public int BillId { get; set; }

        [Required(ErrorMessage = "Proszę wybrać rachunek")]
        public int SelectedBillNameId { get; set; }
        public string BillName { get; set; }

        [Required(ErrorMessage = "Proszę wybrać odbiorcę")]
        public int SelectedRecipientId { get; set; }

        [Required(ErrorMessage = "Proszę podać kwotę")]
        [RegularExpression(@"([0-9]){1,6}(,\d{1,2})?", ErrorMessage = "Podana kwota musi być</br> liczbą z przedzialu </br>od 0 do 999999,99")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Proszę podać datę")]
        public string PaymentDate { get; set; }

        public string RequiredDate { get; set; }

        public List<SelectListItem> Recipients { get; set; }
        public List<SelectBill> Bills { get; set; }

        public CrudBillsViewModel()
        {
            Bills = new List<SelectBill>();
        }
    }
}