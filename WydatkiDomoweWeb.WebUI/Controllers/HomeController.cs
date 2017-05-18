﻿using WydatkiDomoweWeb.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.WebUI.Infrastructure.Filters;

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
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetBill(FilterBillViewModel filterModel, int page = 1)
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
                         }).FilterByCheckbox(filterModel);

            BillViewModel model = new BillViewModel
            {
                Bills = bills.OrderByDescending(b => b.PaymentDate).Skip((page - 1) * PageSize).Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = bills.Count()
                }
            };

            return PartialView(model);
        }

        [HttpGet]
        public PartialViewResult Filter(FilterBillViewModel filterModel)
        {
            if (filterModel.CheckboxItems.Count() == 0)
            {
                filterModel.CheckboxItems = (from bn in billNameRepository.BillNames
                                    select new CheckboxModel
                                    {
                                        Name = bn.Name,
                                        IsChecked = true
                                    }).ToList();
            }

            return PartialView(filterModel.CheckboxItems);  
        }

        [HttpPost]
        public RedirectToRouteResult Filter(FilterBillViewModel filterModel, List<CheckboxModel> model)
        {
            filterModel.CheckboxItems = model;
            return RedirectToAction("GetBill");
        }
    }
}