using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WydatkiDomoweWeb.WebUI.Models;
using System.Collections;
using WydatkiDomoweWeb.WebUI.Infrastructure.Filters;

namespace WydatkiDomoweWeb.WebUI.Infrastructure.Filters.Tests
{
    [TestClass()]
    public class FiltersTests
    {
        private List<BillViewModel> listBill;
        private List<CheckboxModel> listCheckbox;

        [TestInitialize]
        public void Initialize()
        {
            listBill = new List<BillViewModel>
            {
                new BillViewModel {BillId = 0, BillName="Bill0", Recipient = "Recipient0", Amount = 0.00M, PaymentDate = DateTime.Parse("2017-01-01"), RequiredDate = DateTime.Parse("2017-01-11")},
                new BillViewModel {BillId = 1, BillName="Bill1", Recipient = "Recipient1", Amount = 1.00M, PaymentDate = DateTime.Parse("2017-01-02"), RequiredDate = DateTime.Parse("2017-01-11")},
                new BillViewModel {BillId = 2, BillName="Bill2", Recipient = "Recipient2", Amount = 2.00M, PaymentDate = DateTime.Parse("2017-01-03"), RequiredDate = DateTime.Parse("2017-01-11")},
                new BillViewModel {BillId = 3, BillName="Bill3", Recipient = "Recipient3", Amount = 3.00M, PaymentDate = DateTime.Parse("2017-01-04"), RequiredDate = DateTime.Parse("2017-01-11")},
                new BillViewModel {BillId = 4, BillName="Bill4", Recipient = "Recipient4", Amount = 4.00M, PaymentDate = DateTime.Parse("2017-01-05"), RequiredDate = DateTime.Parse("2017-01-11")},
            };

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
        public void FilterByCheckboxTest()
        {
            FilterBillsViewModel filter = new FilterBillsViewModel();
            filter.CheckboxItems = listCheckbox;

            IEnumerable<BillViewModel> result = listBill.FilterByCheckbox(filter);

            Assert.IsTrue(result.Count() == 3);
            Assert.AreEqual("Bill0", result.ElementAt(0).BillName);
            Assert.AreEqual("Bill2", result.ElementAt(1).BillName);
            Assert.AreEqual("Bill4", result.ElementAt(2).BillName);
        }

        [TestMethod()]
        public void FilterByDateRangeTest()
        {
            FilterBillsViewModel filter = new FilterBillsViewModel();
            filter.CheckboxItems = listCheckbox;
            filter.MinDate = "01.01.2017";
            filter.MaxDate = "03.01.2017";

            IEnumerable<BillViewModel> result = listBill.FilterByDateRange(filter);

            Assert.IsTrue(result.Count() == 3);
            Assert.AreEqual(DateTime.Parse("2017-01-01"), result.ElementAt(0).PaymentDate);
            Assert.AreEqual(DateTime.Parse("2017-01-02"), result.ElementAt(1).PaymentDate);
            Assert.AreEqual(DateTime.Parse("2017-01-03"), result.ElementAt(2).PaymentDate);
        }
    }
}
