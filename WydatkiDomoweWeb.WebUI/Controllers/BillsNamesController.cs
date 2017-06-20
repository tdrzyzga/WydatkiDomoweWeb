﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.WebUI.Models;
using WydatkiDomoweWeb.Domain.Abstract;

namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class BillsNamesController : Controller
    {
        private IBillNameRepository billNameRepository;

        public int PageSize = 10;

        public BillsNamesController(IBillNameRepository billName)
        {
            this.billNameRepository = billName;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetBillsNames(int page = 1)
        {
            var billsNames = (from bn in billNameRepository.BillNames
                         select new BillNameModel
                         {
                             Id = bn.BillNameID,
                             Name = bn.Name,
                             FirstPaymentDate = bn.FirstPaymentDate,
                             PaymentsFerquency = bn.PaymentsFrequency

                         });

            BillsNamesViewModel model = new BillsNamesViewModel
            {
                BillsNames = billsNames.OrderByDescending(bn => bn.PaymentsFerquency).Skip((page - 1) * PageSize).Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = billsNames.Count()
                }
            };

            return PartialView(model);
        }
    }
}
