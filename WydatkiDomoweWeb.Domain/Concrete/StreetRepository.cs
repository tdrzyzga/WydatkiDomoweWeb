using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Concrete
{
    public class StreetRepository : IStreetRepository
    {
        private HouseholdExpensesContext context = new HouseholdExpensesContext();

        public IEnumerable<Street> Streets
        {
            get { return context.Streets; }
        }

        public int Add(string street)
        {
            context.Streets.Add(new Street { Name = street });

            context.SaveChanges();

            return context.Streets.Single(s => s.Name == street).StreetID;
        }

        public int? Exists(string street)
        {
            bool streetExists = context.Streets.Any(s => s.Name == street);

            if (streetExists)
                return context.Streets.Single(s => s.Name == street).StreetID;
            else
                return null;
        }
    }
}
