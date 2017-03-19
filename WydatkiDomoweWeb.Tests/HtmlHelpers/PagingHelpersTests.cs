using Microsoft.VisualStudio.TestTools.UnitTesting;
using WydatkiDomoweWeb.WebUI.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.HtmlHelpers.Tests
{
    [TestClass()]
    public class PagingHelpersTests
    {
        [TestMethod()]
        public void PageLinksTest()
        {
            HtmlHelper myHelper = null;

            PagingInfo pagingInfo = new PagingInfo
            {
                TotalItems = 21,
                ItemsPerPage = 10,
                CurrentPage = 3
            };

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, i => "Strona" + i);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Strona1"">1</a><a class=""btn btn-default"" href=""Strona2"">2</a><a class=""btn btn-default btn-primary selected"" href=""Strona3"">3</a>", result.ToString());

        }
    }
}