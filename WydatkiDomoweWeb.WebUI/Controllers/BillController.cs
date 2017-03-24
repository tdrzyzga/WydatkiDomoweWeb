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
            if ((List<CheckboxModel>)Session["List"] != null)
                checkboxList = (List<CheckboxModel>)Session["List"];
            
            Session["ListToCheckbox"] = checkboxList;

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

            List<BillModel> currentList = new List<BillModel>();

            if (checkboxList.Count() != 0)
            {
                for (int i = 0; i < checkboxList.Count(); i++)
                {
                    var list = query.Where(bn => bn.BillName == checkboxList[i].Name && checkboxList[i].IsChecked);
                    currentList.AddRange(list);
                }
            }
            else
            {
                currentList.AddRange(query);
            }

            BillListViewModel model = new BillListViewModel
            {
                Bills = currentList.OrderBy(b => b.Amount).Skip((page - 1) * PageSize).Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = currentList.Count()
                }
            };

            return View(model);
        }       
    }
}