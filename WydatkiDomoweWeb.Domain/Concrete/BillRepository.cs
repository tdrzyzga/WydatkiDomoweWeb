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

        public void AddBill(Bill bill)
        {
            context.Bills.Add(bill);

            context.SaveChanges();
        }

        public void UpdateBill(Bill bill)
        {
            Bill dbEntry = context.Bills.Find(bill.BillsID);

            if (dbEntry != null)
            {
                dbEntry.BillNameID = bill.BillNameID;
                dbEntry.RecipientID = bill.RecipientID;
                dbEntry.Amount = bill.Amount;
                dbEntry.PaymentDate = bill.PaymentDate;
                dbEntry.RequiredDate = bill.RequiredDate;
            }

            context.SaveChanges();
        }

        public void DeleteBill(int billId)
        {
            Bill dbEntry = context.Bills.Find(billId);

            if (dbEntry != null)
            {
                context.Bills.Remove(dbEntry);
            }

            context.SaveChanges();
        }
        
    }
}
