using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class BillController : Controller
    {
        private IBillRepository repository;

        public int PageSize = 10;

        public BillController(IBillRepository billRepository)
        {
            this.repository = billRepository;
        }

        public ViewResult List()
        {
            BillListViewModel model = new BillListViewModel
            {
                Bills = (from b in repository.Bills
                         join bn in repository.BillNames
                            on b.BillNameID equals bn.BillNameID
                         join r in repository.Recipients
                            on b.RecipientID equals r.RecipientID
                         select new BillView
                         {
                             Id = b.BillsID,
                             BillName = bn.Name,
                             Recipient = r.Name,
                             Amount = b.Amount
                         })
            };   
                             
            return View(model);
        }
    }
}