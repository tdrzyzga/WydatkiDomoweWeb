using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Abstract
{
    public interface IPostCodeRepository
    {
        IEnumerable<PostCode> PostCodes { get; }
        int Add(string postCode);
        int? Exists(string postCode);
    }
}
