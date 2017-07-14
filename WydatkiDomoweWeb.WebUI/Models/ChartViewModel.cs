using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Highsoft.Web.Mvc.Charts;

namespace WydatkiDomoweWeb.WebUI.Models
{
    public class ChartViewModel
    {
        public List<string> Category { get; set; }
        public IEnumerable<ColumnSeries> SeriesData { get; set; }
    }
}