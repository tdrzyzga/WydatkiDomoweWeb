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

namespace WydatkiDomoweWeb.WebUI.Filters.Tests
{
    [TestClass()]
    public class BillFilterTests
    {
        [TestMethod()]
        public void FilterBillsTest()
        {
            List<BillModel> listBill = new List<BillModel>
            {
                new BillModel {Id = 0, BillName="Bill0", Recipient = "Recipient0", Amount = 0.00M, PaymentDate = DateTime.Now, RequiredDate = DateTime.Now.AddDays(60)},
                new BillModel {Id = 1, BillName="Bill1", Recipient = "Recipient1", Amount = 1.00M, PaymentDate = DateTime.Now.AddDays(1), RequiredDate = DateTime.Now.AddDays(60)},
                new BillModel {Id = 2, BillName="Bill2", Recipient = "Recipient2", Amount = 2.00M, PaymentDate = DateTime.Now.AddDays(2), RequiredDate = DateTime.Now.AddDays(60)},
                new BillModel {Id = 3, BillName="Bill3", Recipient = "Recipient3", Amount = 3.00M, PaymentDate = DateTime.Now.AddDays(3), RequiredDate = DateTime.Now.AddDays(60)},
                new BillModel {Id = 4, BillName="Bill4", Recipient = "Recipient4", Amount = 4.00M, PaymentDate = DateTime.Now.AddDays(4), RequiredDate = DateTime.Now.AddDays(60)},
            };

            List<CheckboxModel> listCheckbox = new List<CheckboxModel>
            {
                new CheckboxModel {Name = "Bill0", IsChecked = true},
                new CheckboxModel {Name = "Bill1", IsChecked = false},
                new CheckboxModel {Name = "Bill2", IsChecked = true},
                new CheckboxModel {Name = "Bill3", IsChecked = false},
                new CheckboxModel {Name = "Bill4", IsChecked = true}
            };

            CheckboxViewModel checkbox = new CheckboxViewModel();
            checkbox.Items = listCheckbox;

            CheckboxFilter checkboxFilter = new CheckboxFilter(checkbox);
            IEnumerable<BillModel> result = checkboxFilter.Filter(listBill);

            Assert.AreEqual(result.Count(), 3);
            Assert.AreEqual(result.ElementAt(2), listBill.ElementAt(4));
        }
    }
}