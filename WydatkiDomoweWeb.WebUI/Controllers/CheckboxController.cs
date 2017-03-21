using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;

namespace WydatkiDomoweWeb.WebUI.Controllers
{
    public class CheckboxController : Controller
    {
        private IBillRepository repository;

        public CheckboxController(IBillRepository billRepository)
        {
            this.repository = billRepository;
        }

        public PartialViewResult Checkbox()
        {
            IEnumerable<string> checkboxName = repository.BillNames.Select(x => x.Name).OrderByDescending(x => x);

            return PartialView(checkboxName);
        }

    }
}
