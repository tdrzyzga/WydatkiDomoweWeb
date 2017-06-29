using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Abstract
{
    public interface IStreetRepository
    {
        IEnumerable<Street> Streets { get; }
        int Add(string street);
        int? Exists(string street);
    }
}
