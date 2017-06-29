using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class RecipientViewModel
    {
        public int RecipientId { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać numer konta")]
        [RegularExpression(@"([0-9]{26})", ErrorMessage = "Numer konta musi posiadać 26 znaków i nie zawierać liter")]
        public string Account { get; set; }

        [Required(ErrorMessage = "Proszę podać kod pocztowy")]
        [RegularExpression(@"([0-9]{2})([-]{1})([0-9]{3})", ErrorMessage = "XX-YYY")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę miasta")]
        [RegularExpression(@"[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]*\s*[-]?\s*[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+\s*", ErrorMessage = "Miasto nie może zawierać cyfr oraz znaków: /, _, -")]
        public string City { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę ulicy")]
        [RegularExpression(@"[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]*\s*[-]?\s*[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+\s*", ErrorMessage = "Ulica nie może zawierać cyfr oraz znaków: /, _, -")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Proszę podać numer")]
        public string BuildingNr { get; set; }
    }

    public class RecipientsViewModel
    {
        public IEnumerable<RecipientViewModel> Recipients { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }   
}