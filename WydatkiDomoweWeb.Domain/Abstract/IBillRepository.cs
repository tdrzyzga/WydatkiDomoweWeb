﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Abstract
{
    public interface IBillRepository
    {
        IEnumerable<Bill> Bills { get; }
        void Add(Bill bill);
        void Update(Bill bill);
        void Delete(int billId);
    }
}
