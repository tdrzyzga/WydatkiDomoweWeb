using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Concrete
{
    public class BillRepository : IBillRepository
    {
        private HouseholdExpensesContext context = new HouseholdExpensesContext();

        public IEnumerable<Bill> Bills
        {
            get { return context.Bills; }
        }

        public IEnumerable<BillName> BillNames
        {
            get { return context.BillNames; }
        }

        public IEnumerable<Recipient> Recipients
        {
            get { return context.Recipients; }
        }
    }
}
