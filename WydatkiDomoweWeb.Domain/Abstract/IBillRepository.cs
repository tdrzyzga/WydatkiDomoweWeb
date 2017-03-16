using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Abstract
{
    public interface IBillRepository
    {
        IEnumerable<Bill> Bills { get; }
        IEnumerable<BillName> BillNames { get; }
        IEnumerable<Recipient> Recipients { get; }
    }
}
