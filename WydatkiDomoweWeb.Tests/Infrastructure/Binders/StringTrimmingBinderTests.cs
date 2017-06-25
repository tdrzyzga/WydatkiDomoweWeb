using Microsoft.VisualStudio.TestTools.UnitTesting;
using WydatkiDomoweWeb.WebUI.Infrastructure.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Web.Mvc;
using System.Collections.Specialized;

namespace WydatkiDomoweWeb.WebUI.Infrastructure.Binders.Tests
{
    [TestClass()]
    public class StringTrimmingBinderTests
    {
        [TestMethod()]
        public void BindModelTest()
        {
            /*Mock<ControllerContext> mockControllerContext = new Mock<ControllerContext>();
            Mock<ValueProviderResult> valueProviderResult = new Mock<ValueProviderResult>();
            valueProviderResult.Setup(m => m).Returns(new ValueProviderResult(null, " o   ja pier  le  ", null));
            valueProviderResult.Setup(m => m.AttemptedValue).Returns(" o   ja pier  le  ");
            Mock<IValueProvider> valueProvider = new Mock<IValueProvider>();
            valueProvider.Setup(m => m.GetValue("Trim")).Returns(valueProviderResult.Object);
            
            ModelBindingContext bindingContext = new ModelBindingContext
            {
                ValueProvider = valueProvider.Object
            };

            StringTrimmingBinder trim = new StringTrimmingBinder();

            string result = trim.BindModel(mockControllerContext.Object, bindingContext).ToString();

            Assert.AreEqual("o ja pierdole", result);*/
        }
    }
}