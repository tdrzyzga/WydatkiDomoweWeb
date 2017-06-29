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
        void Add(BillName billName);
        void Update(BillName billName);
        void Delete(int billNameId);
        bool Exists(string name);
    }
}
