using Microsoft.VisualStudio.TestTools.UnitTesting;
using WydatkiDomoweWeb.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WydatkiDomoweWeb.Domain.Abstract;
using Moq;
using WydatkiDomoweWeb.Domain.Entities;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Controllers.Tests
{
    [TestClass()]
    public class BillsNamesControllerTests
    {
        [TestMethod()]
        public void GetBillsNamesTest()
        {
            Mock<IBillNameRepository> mockBillNames = new Mock<IBillNameRepository>();
            mockBillNames.Setup(m => m.BillNames).Returns(new BillName[]
            {
                new BillName {BillNameID = 0, Name = "Bill0", FirstPaymentDate = DateTime.Parse("2017-01-01"), PaymentsFrequency = 10 },
                new BillName {BillNameID = 1, Name = "Bill1", FirstPaymentDate = DateTime.Parse("2017-01-01"), PaymentsFrequency = 10 },
                new BillName {BillNameID = 2, Name = "Bill2", FirstPaymentDate = DateTime.Parse("2017-01-01"), PaymentsFrequency = 10 },
                new BillName {BillNameID = 3, Name = "Bill3", FirstPaymentDate = DateTime.Parse("2017-01-01"), PaymentsFrequency = 10 },
                new BillName {BillNameID = 4, Name = "Bill4", FirstPaymentDate = DateTime.Parse("2017-01-01"), PaymentsFrequency = 10 },
            });

            BillsNamesController controller = new BillsNamesController(mockBillNames.Object);
            controller.PageSize = 2;

            BillsNamesViewModel result = (BillsNamesViewModel)controller.GetBillsNames(2).Model;
            PagingInfo pageInfo = result.PagingInfo;

            Assert.AreEqual(2, pageInfo.CurrentPage);
            Assert.AreEqual(2, pageInfo.ItemsPerPage);
            Assert.AreEqual(3, pageInfo.TotalPages);
            Assert.AreEqual(5, pageInfo.TotalItems);

            Assert.IsTrue(result.BillsNames.Count() == 2);
            Assert.AreEqual("Bill2", result.BillsNames.ElementAt(0).Name);
            Assert.AreEqual("Bill3", result.BillsNames.ElementAt(1).Name);

        }
    }
}