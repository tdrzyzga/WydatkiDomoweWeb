using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Concrete
{
    public class RecipientRepository : IRecipientRepository
    {
        private HouseholdExpensesContext context = new HouseholdExpensesContext();

        public IEnumerable<Recipient> Recipients
        {
            get { return context.Recipients; }
        }

        public void Add(Recipient recipient)
        {
            context.Recipients.Add(recipient);

            context.SaveChanges();
        }
    }
}
