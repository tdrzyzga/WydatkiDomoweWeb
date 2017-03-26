using Microsoft.VisualStudio.TestTools.UnitTesting;
using WydatkiDomoweWeb.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.WebUI.Models;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.WebUI.Controllers.Tests
{
    [TestClass()]
    public class BillControllerTests
    {
        [TestMethod()]
        public void ListTest()
        {
            Mock<IBillRepository> mock = new Mock<IBillRepository>();
            mock.Setup(m => m.Bills).Returns(new Bill[]
            {
                new Bill {BillNameID = 0, RecipientID = 0 , Amount = 0.0M, PaymentDate = DateTime.Now, RequiredDate = DateTime.Now },
                new Bill {BillNameID = 1, RecipientID = 1 , Amount = 1.0M, PaymentDate = DateTime.Now, RequiredDate = DateTime.Now },
                new Bill {BillNameID = 2, RecipientID = 2 , Amount = 2.0M, PaymentDate = DateTime.Now, RequiredDate = DateTime.Now },
                new Bill {BillNameID = 3, RecipientID = 3 , Amount = 3.0M, PaymentDate = DateTime.Now, RequiredDate = DateTime.Now },
                new Bill {BillNameID = 4, RecipientID = 4 , Amount = 4.0M, PaymentDate = DateTime.Now, RequiredDate = DateTime.Now },
            });

            mock.Setup(m => m.BillNames).Returns(new BillName[]
            {
                new BillName {BillNameID = 0, Name = "Bill0", FirstPaymentDate = DateTime.Now, PaymentsFrequency = 0 },
                new BillName {BillNameID = 1, Name = "Bill1", FirstPaymentDate = DateTime.Now, PaymentsFrequency = 1 },
                new BillName {BillNameID = 2, Name = "Bill2", FirstPaymentDate = DateTime.Now, PaymentsFrequency = 2 },
                new BillName {BillNameID = 3, Name = "Bill3", FirstPaymentDate = DateTime.Now, PaymentsFrequency = 3 },
                new BillName {BillNameID = 4, Name = "Bill4", FirstPaymentDate = DateTime.Now, PaymentsFrequency = 4 },
            });

            mock.Setup(m => m.Recipients).Returns(new Recipient[]
            {
                new Recipient { RecipientID = 0, Name = "Recipient0", Account = "Account0", BuildingNR = "Nr0", CityID = 0, StreetID = 0, PostCodeID= 0 },
                new Recipient { RecipientID = 1, Name = "Recipient1", Account = "Account1", BuildingNR = "Nr1", CityID = 1, StreetID = 1, PostCodeID= 1 },
                new Recipient { RecipientID = 2, Name = "Recipient2", Account = "Account2", BuildingNR = "Nr2", CityID = 2, StreetID = 2, PostCodeID= 2 },
                new Recipient { RecipientID = 3, Name = "Recipient3", Account = "Account3", BuildingNR = "Nr3", CityID = 3, StreetID = 3, PostCodeID= 3 },
                new Recipient { RecipientID = 4, Name = "Recipient4", Account = "Account4", BuildingNR = "Nr4", CityID = 4, StreetID = 4, PostCodeID= 4 },
            });

            BillController controller = new BillController(mock.Object);
            controller.PageSize = 2;

            BillViewModel result = (BillViewModel)controller.List(2).Model;
            PagingInfo pageInfo = result.PagingInfo;

            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 2);
            Assert.AreEqual(pageInfo.TotalPages, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);

            BillView[] billView = result.Bills.ToArray();

            Assert.IsTrue(billView.Length == 2);
            Assert.AreEqual(billView[0].BillName, "Bill2");
            Assert.AreEqual(billView[1].BillName, "Bill3");
        }
    }
}