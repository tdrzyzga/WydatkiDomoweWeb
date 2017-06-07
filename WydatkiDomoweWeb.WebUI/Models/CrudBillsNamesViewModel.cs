using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class CrudBillsNamesViewModel
    {
        public int BillNameId { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać datę")]
        public string FirstPaymentDate { get; set; }

        [Required(ErrorMessage = ("Proszę podać częstotliwość wpłat"))]
        [RegularExpression(@"([0-9]){1,3}", ErrorMessage = "Częstotliwość wpłat musi</br>być liczbą z przedziału</br>od 1 do 366")]
        [Range(1, 366, ErrorMessage = "Częstotliwość wpłat musi być liczbą z przedziału od 1 do 366")]
        public int PaymentsFerquency { get; set; }
    }
}