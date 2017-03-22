using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WydatkiDomoweWeb.WebUI.Models.Abstract
{
    public interface ICheckboxListViewModel
    {
       List<CheckboxModel> CheckboxItems { get; set; }
    }
}
