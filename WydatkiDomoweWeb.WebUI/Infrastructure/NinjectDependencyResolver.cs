using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WydatkiDomoweWeb.Domain.Abstract;
using WydatkiDomoweWeb.Domain.Concrete;
using WydatkiDomoweWeb.WebUI.Models;

namespace WydatkiDomoweWeb.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IBillRepository>().To<BillRepository>();
            kernel.Bind<IBillNameRepository>().To<BillNameRepository>();
            kernel.Bind<IRecipientRepository>().To<RecipientRepository>();
            kernel.Bind<IPostCodeRepository>().To<PostCodeRepository>();
            kernel.Bind<ICityRepository>().To<CityRepository>();
            kernel.Bind<IStreetRepository>().To<StreetRepository>();
        }
    }
}