using Microsoft.VisualStudio.TestTools.UnitTesting;
using WydatkiDomoweWeb.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.Domain.Entities;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Controllers.Tests
{
    [TestClass()]
    public class CrudBillControllerTests
    {
        private Mock<IBillRepository> mockBills;
        private Mock<IBillNameRepository> mockBillNames;
        private Mock<IRecipientRepository> mockRecipients;

        [TestInitialize]
        public void Initialize()
        {
            mockBills = new Mock<IBillRepository>();
            mockBills.Setup(m => m.Bills).Returns(new Bill[]
            {
                new Bill {BillNameID = 0, RecipientID = 0 , Amount = 0.0M, PaymentDate = DateTime.Parse("2017-01-05"), RequiredDate = DateTime.Parse("2017-01-11") },
                new Bill {BillNameID = 1, RecipientID = 1 , Amount = 1.0M, PaymentDate = DateTime.Parse("2017-01-04"), RequiredDate = DateTime.Parse("2017-01-11") },
                new Bill {BillNameID = 2, RecipientID = 2 , Amount = 2.0M, PaymentDate = DateTime.Parse("2017-01-03"), RequiredDate = DateTime.Parse("2017-01-11") },
                new Bill {BillNameID = 3, RecipientID = 3 , Amount = 3.0M, PaymentDate = DateTime.Parse("2017-01-02"), RequiredDate = DateTime.Parse("2017-01-11") },
            });

            mockBillNames = new Mock<IBillNameRepository>();
            mockBillNames.Setup(m => m.BillNames).Returns(new BillName[]
            {
                new BillName {BillNameID = 0, Name = "Bill0", FirstPaymentDate = DateTime.Parse("2017-01-01"), PaymentsFrequency = 10 },
                new BillName {BillNameID = 1, Name = "Bill1", FirstPaymentDate = DateTime.Parse("2017-01-01"), PaymentsFrequency = 10 },
                new BillName {BillNameID = 2, Name = "Bill2", FirstPaymentDate = DateTime.Parse("2017-01-01"), PaymentsFrequency = 10 },
                new BillName {BillNameID = 3, Name = "Bill3", FirstPaymentDate = DateTime.Parse("2017-01-01"), PaymentsFrequency = 10 },
                new BillName {BillNameID = 4, Name = "Bill4", FirstPaymentDate = DateTime.Parse("2017-01-01"), PaymentsFrequency = 10 },
            });

            mockRecipients = new Mock<IRecipientRepository>();
            mockRecipients.Setup(m => m.Recipients).Returns(new Recipient[]
            {
                new Recipient { RecipientID = 0, Name = "Recipient0", Account = "Account0", BuildingNR = "Nr0", CityID = 0, StreetID = 0, PostCodeID= 0 },
                new Recipient { RecipientID = 1, Name = "Recipient1", Account = "Account1", BuildingNR = "Nr1", CityID = 1, StreetID = 1, PostCodeID= 1 },
                new Recipient { RecipientID = 2, Name = "Recipient2", Account = "Account2", BuildingNR = "Nr2", CityID = 2, StreetID = 2, PostCodeID= 2 },
                new Recipient { RecipientID = 3, Name = "Recipient3", Account = "Account3", BuildingNR = "Nr3", CityID = 3, StreetID = 3, PostCodeID= 3 },
                new Recipient { RecipientID = 4, Name = "Recipient4", Account = "Account4", BuildingNR = "Nr4", CityID = 4, StreetID = 4, PostCodeID= 4 },
            });
        }

        [TestMethod()]
        public void HttpGetMethodAddBillTest()
        {     
            CrudBillsController controller = new CrudBillsController(mockBills.Object, mockBillNames.Object, mockRecipients.Object);

            CrudBillsViewModel result = (CrudBillsViewModel)controller.AddBill().Model;

            Assert.AreEqual("Bill2", result.Bills[2].Name);
            Assert.AreEqual(DateTime.Parse("2017-01-21"), result.Bills[2].Date);
            Assert.AreEqual("Bill3", result.Bills[3].Name);
            Assert.AreEqual(DateTime.Parse("2017-01-21"), result.Bills[3].Date);
            Assert.AreEqual("Bill4", result.Bills[4].Name);
            Assert.AreEqual(DateTime.Parse("2017-01-01"), result.Bills[4].Date);
        }
    }
}