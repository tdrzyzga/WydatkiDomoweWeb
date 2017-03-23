using WydatkiDomoweWeb.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.WebUI.Models.Abstract;

namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class BillController : Controller
    {
        private IBillRepository repository;
        private List<CheckboxModel> checkboxList;

        public int PageSize = 10;

        public BillController(IBillRepository billRepository)
        {
            this.repository = billRepository;
            checkboxList = new List<CheckboxModel>();
        }

        [HttpGet]
        public ViewResult List(int page = 1)
        {
            if ((List<CheckboxModel>)TempData["List"] != null)
                checkboxList = (List<CheckboxModel>)TempData["List"];
            
            TempData["ListToCheckbox"] = checkboxList;
            var query = GetBillModelList();

            return View(CreateBillListViewModel(query, page));
        }

        private BillListViewModel CreateBillListViewModel(IEnumerable<BillModel> query, int page)
        {
            BillListViewModel model = new BillListViewModel
            {
                Bills = query.OrderBy(b => b.Amount).Skip((page - 1) * PageSize).Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = query.Count()
                }
            };
            return model;
        }

        private IEnumerable<BillModel> GetBillModelList()
        {
            var query = (from b in repository.Bills
                         join bn in repository.BillNames
                            on b.BillNameID equals bn.BillNameID
                         join r in repository.Recipients
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

            if (checkboxList.Count() != 0)
                query = CheckboxCheck(query);

            return query;
        }

        private IEnumerable<BillModel> CheckboxCheck(IEnumerable<BillModel> query)
        {
            List<BillModel> current = new List<BillModel>();

            for (int i = 0; i < checkboxList.Count(); i++)
            {
                var obj = query.Where(bn => bn.BillName == checkboxList[i].Name && checkboxList[i].IsChecked);
                current.AddRange(obj);
            }

            return current;
        }
    }
}