using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class BillNameViewModel
    {
        public int BillNameId { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę")]
        [Remote("ValidateName", "CrudBillsNames")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać datę")]
        public string FirstPaymentDate { get; set; }

        [Required(ErrorMessage = ("Proszę podać częstotliwość wpłat"))]
        [RegularExpression(@"([0-9]){1,3}", ErrorMessage = "Częstotliwość wpłat musi</br>być liczbą z przedziału</br>od 1 do 366")]
        [Range(1, 366, ErrorMessage = "Częstotliwość wpłat musi być liczbą z przedziału od 1 do 366")]
        public int PaymentsFerquency { get; set; }
    }

    public class BillsNamesViewModel
    {
        public IEnumerable<BillNameViewModel> BillsNames { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}