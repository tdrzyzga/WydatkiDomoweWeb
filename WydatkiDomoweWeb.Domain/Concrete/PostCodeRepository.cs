﻿using System;
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
    }
}
