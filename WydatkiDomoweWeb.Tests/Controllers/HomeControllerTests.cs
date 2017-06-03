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
using System.Web.Mvc;

namespace WydatkiDomoweWeb.WebUI.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        private Mock<IBillRepository> mockBills;
        private Mock<IBillNameRepository> mockBillNames;
        private Mock<IRecipientRepository> mockRecipients;
        private List<CheckboxModel> listCheckbox;

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
                new Bill {BillNameID = 4, RecipientID = 4 , Amount = 4.0M, PaymentDate = DateTime.Parse("2017-01-01"), RequiredDate = DateTime.Parse("2017-01-11") },

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

            listCheckbox = new List<CheckboxModel>
            {
                new CheckboxModel {Name = "Bill0", IsChecked = true},
                new CheckboxModel {Name = "Bill1", IsChecked = false},
                new CheckboxModel {Name = "Bill2", IsChecked = true},
                new CheckboxModel {Name = "Bill3", IsChecked = false},
                new CheckboxModel {Name = "Bill4", IsChecked = true}
            };

        }
        [TestMethod()]
        public void GetBillTest()
        {
            HomeController controller = new HomeController(mockBills.Object, mockBillNames.Object, mockRecipients.Object);
            controller.PageSize = 2;
            FilterBillsViewModel checkbox = new FilterBillsViewModel();
            checkbox.CheckboxItems = listCheckbox;            

            BillsViewModel result = (BillsViewModel)controller.GetBills(checkbox, 1).Model;
            PagingInfo pageInfo = result.PagingInfo;

            Assert.AreEqual(1, pageInfo.CurrentPage);
            Assert.AreEqual(2, pageInfo.ItemsPerPage);
            Assert.AreEqual(2, pageInfo.TotalPages);
            Assert.AreEqual(3, pageInfo.TotalItems);

            BillModel[] billView = result.Bills.ToArray();

            Assert.IsTrue(billView.Length == 2);
            Assert.AreEqual("Bill0", billView[0].BillName);
            Assert.AreEqual("Bill2", billView[1].BillName);
        }

        [TestMethod()]
        public void HttpGetFilterTest()
        {
            HomeController controller = new HomeController(mockBills.Object, mockBillNames.Object, mockRecipients.Object);
            FilterBillsViewModel checkbox = new FilterBillsViewModel();
                        
            FilterBillsViewModel resultCheckbox = (FilterBillsViewModel)controller.Filter(checkbox).Model;

            Assert.AreEqual("Bill0", resultCheckbox.CheckboxItems[0].Name);
            Assert.AreEqual("Bill1", resultCheckbox.CheckboxItems[1].Name);
            Assert.AreEqual(true, resultCheckbox.CheckboxItems[0].IsChecked);
            Assert.AreEqual(true, resultCheckbox.CheckboxItems[1].IsChecked);
        }

        [TestMethod()]
        public void HttpPostFilterTest()
        {
            HomeController controller = new HomeController(mockBills.Object, mockBillNames.Object, mockRecipients.Object);
            FilterBillsViewModel checkbox = new FilterBillsViewModel();

            RedirectToRouteResult result = (RedirectToRouteResult)controller.FilterPost(checkbox);

            Assert.IsNotNull(result);
            Assert.AreEqual("GetBills", result.RouteValues["action"]);
        }
    }
}