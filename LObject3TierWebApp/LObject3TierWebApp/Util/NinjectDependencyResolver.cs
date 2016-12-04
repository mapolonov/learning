using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LObject3Tier.BLL.Interfaces;
using LObject3Tier.BLL.Services;
//using LObject.Domain.Interfaces;
//using LObject.Infrastructure.Data;
using Ninject;

namespace LObjectWebApp.Util
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
            kernel.Bind<ICourseService>().To<CourseService>();
            //kernel.Bind<IOrder>().To<CacheOrder>();
        }
    }
}