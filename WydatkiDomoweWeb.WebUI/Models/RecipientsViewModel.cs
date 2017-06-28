using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class RecipientViewModel
    {
        public int RecipientId { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNr { get; set; }
    }

    public class RecipientsViewModel
    {
        public IEnumerable<RecipientViewModel> Recipients { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }   
}