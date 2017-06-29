using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Concrete
{
    public class CityRepository : ICityRepository
    {
        private HouseholdExpensesContext context = new HouseholdExpensesContext();

        public IEnumerable<City> Cities
        {
            get { return context.Cities; }
        }

        public int Add(string city)
        {
            context.Cities.Add(new City { Name = city });

            context.SaveChanges();

            return context.Cities.Single(c => c.Name == city).CityID;
        }

        public int? Exists(string city)
        {
            bool cityExists = context.Cities.Any(c => c.Name == city);

            if (cityExists)
                return context.Cities.Single(c => c.Name == city).CityID;
            else
                return null;
        }
    }
}
