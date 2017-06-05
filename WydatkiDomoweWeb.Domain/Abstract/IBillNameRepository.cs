using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Abstract
{
    public interface IBillNameRepository
    {
        IEnumerable<BillName> BillNames { get; }
        void AddBillName(BillName billName);
        void UpdateBillName(BillName billName);
        void DeleteBillName(int billNameId);
    }
}
