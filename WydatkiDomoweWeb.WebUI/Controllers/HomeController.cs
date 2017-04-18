using WydatkiDomoweWeb.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.WebUI.Filters;

namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBillRepository billRepository;
        private IBillNameRepository billNameRepository;
        private IRecipientRepository recipientRepository;

        public int PageSize = 10;

        public HomeController(IBillRepository bill, IBillNameRepository billName, IRecipientRepository recipient)
        {
            this.billRepository = bill;
            this.billNameRepository = billName;
            this.recipientRepository = recipient;
        }

        [HttpGet]
        public ViewResult Index(CheckboxViewModel checkbox, int page = 1)
        {
            var bills = (from b in billRepository.Bills
                         join bn in billNameRepository.BillNames
                            on b.BillNameID equals bn.BillNameID
                         join r in recipientRepository.Recipients
                            on b.RecipientID equals r.RecipientID
                         select new BillModel
                         {
                             Id = b.BillsID,
                             BillName = bn.Name,
                             Recipient = r.Name,
                             Amount = b.Amount,
                             PaymentDate = b.PaymentDate,
                             RequiredDate = b.RequiredDate
                         });

            CheckboxFilter filterCheckbox = new CheckboxFilter(checkbox);
            bills = filterCheckbox.Filter(bills);

            BillViewModel model = new BillViewModel
            {
                Bills = bills.OrderBy(b => b.Amount).Skip((page - 1) * PageSize).Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = bills.Count()
                }
            };

            return View(model);
        }

        [HttpGet]
        public PartialViewResult Checkbox(CheckboxViewModel checkbox)
        {
            if (checkbox.Items.Count() == 0)
            {
                checkbox.Items = (from bn in billNameRepository.BillNames
                                    select new CheckboxModel
                                    {
                                        Name = bn.Name,
                                        IsChecked = true
                                    }).ToList();
            }
            return PartialView(checkbox.Items);  
        }

        [HttpPost]
        public RedirectToRouteResult Checkbox(CheckboxViewModel checkbox, List<CheckboxModel> model)
        {
            checkbox.Items = model;
            return RedirectToAction("Index");
        }


    }
}