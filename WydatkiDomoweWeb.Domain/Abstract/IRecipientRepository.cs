using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Abstract
{
    public interface IRecipientRepository
    {
        IEnumerable<Recipient> Recipients { get; }
        void Add(Recipient recipient);
        bool ExistsName(string name);
        bool ExistsAccount(string account);
    }
}
