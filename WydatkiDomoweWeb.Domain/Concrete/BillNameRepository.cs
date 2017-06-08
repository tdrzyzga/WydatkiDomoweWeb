using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Concrete
{
    public class BillNameRepository : IBillNameRepository
    {
        private HouseholdExpensesContext context = new HouseholdExpensesContext();

        public IEnumerable<BillName> BillNames
        {
            get { return context.BillNames; }
        }

        public void AddBillName(BillName billName)
        {
            context.BillNames.Add(billName);

            context.SaveChanges();
        }

        public void UpdateBillName(BillName billName)
        {
            BillName dbEntry = context.BillNames.Find(billName.BillNameID);

            if (dbEntry != null)
            {
                dbEntry.Name = billName.Name;
                dbEntry.FirstPaymentDate = billName.FirstPaymentDate;
                dbEntry.PaymentsFrequency = billName.PaymentsFrequency;
            }

            context.SaveChanges();
        }

        public void DeleteBillName(int billNameId)
        {
            BillName dbEntry = context.BillNames.Find(billNameId);

            if (dbEntry != null)
            {
                context.BillNames.Remove(dbEntry);
            }

            context.SaveChanges();
        }

        public bool Exists(string name)
        {
            return context.BillNames.Any(bn => bn.Name == name);
        }
    }
}
