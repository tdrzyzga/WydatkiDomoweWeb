using WydatkiDomoweWeb.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;

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

        public ViewResult List(int page = 1)
        {
            var query = (from b in repository.Bills
                         join bn in repository.BillNames
                            on b.BillNameID equals bn.BillNameID
                         join r in repository.Recipients
                            on b.RecipientID equals r.RecipientID
                         select new BillView
                         {
                             Id = b.BillsID,
                             BillName = bn.Name,
                             Recipient = r.Name,
                             Amount = b.Amount,
                             PaymentDate = b.PaymentDate,
                             RequiredDate = b.RequiredDate
                         });

            BillListViewModel model = new BillListViewModel
            {
                Bills = query.OrderBy(b => b.Amount).Skip((page - 1) * PageSize).Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Bills.Count()
                },
            };   
                             
            return View(model);
        }
    }
}