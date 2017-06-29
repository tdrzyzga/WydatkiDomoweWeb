using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Concrete
{
    public class PostCodeRepository : IPostCodeRepository
    {
        private HouseholdExpensesContext context = new HouseholdExpensesContext();

        public IEnumerable<PostCode> PostCodes
        {
            get { return context.PostCodes; }
        }

        public int Add(string postCode)
        {
            context.PostCodes.Add(new PostCode { Name = postCode });

            context.SaveChanges();

            return context.PostCodes.Single(p => p.Name == postCode).PostCodeID;
        }

        public int? Exists(string postCode)
        {
            bool postcodeExists = context.PostCodes.Any(p => p.Name == postCode);

            if (postcodeExists)
                return context.PostCodes.Single(p => p.Name == postCode).PostCodeID;
            else
                return null;
        }
    }
}
