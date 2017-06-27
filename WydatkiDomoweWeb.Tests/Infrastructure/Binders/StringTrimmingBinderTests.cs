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
            Mock<ControllerContext> mockControllerContext = new Mock<ControllerContext>();

            ValueProviderResult valueProviderResult = new ValueProviderResult(null, " o   ja    pierdole  ", System.Globalization.CultureInfo.InvariantCulture);
            
            Mock<IValueProvider> valueProvider = new Mock<IValueProvider>();
            valueProvider.Setup(m => m.GetValue("")).Returns(valueProviderResult);
            
            ModelBindingContext bindingContext = new ModelBindingContext
            {
                ValueProvider = valueProvider.Object
            };

            StringTrimmingBinder binder = new StringTrimmingBinder();

            string result = binder.BindModel(mockControllerContext.Object, bindingContext).ToString();

            Assert.AreEqual("o ja pierdole", result);
        }
    }
}