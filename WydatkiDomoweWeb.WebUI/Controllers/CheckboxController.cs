using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class CheckboxController : Controller
    {
        private IBillRepository repository;
        private CheckboxListViewModel model;

        public CheckboxController(IBillRepository billRepository)
        {
            this.repository = billRepository;
        }

        public PartialViewResult CheckboxList()
        {
            if (model == null)
            {
                model = new CheckboxListViewModel
                {
                    CheckboxItem = (from bn in repository.BillNames
                                    select new CheckboxModel
                                    {
                                        Name = bn.Name,
                                        IsChecked = true
                                    }).ToList()
                };
            }

            return PartialView(model);
        }

    }
}
