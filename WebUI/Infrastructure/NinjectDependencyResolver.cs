using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;
using Ninject;
using System.Web.Mvc;
using System.Configuration;
using Domain.Concrete;
using Domain.Abstract;
using WebUI.Infrastructure.Abstract;
using WebUI.Infrastructure.Concrete;
using Domain.Entities;

namespace WebUI.Infrastructure
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
            Mock<ICharacteristicRepository> mock = new Mock<ICharacteristicRepository>();
            mock.Setup(m => m.Characteristics).Returns(new List<Characteristic>
    {
        new Characteristic { Name = "SimCity", SellingPrice = 1499,Description="1" ,Year="2232"},
        new Characteristic { Name = "TITANFALL", SellingPrice=2299 ,Description="sadsas2dsda",Year="2232"},
        new Characteristic { Name = "Battlefield 4", SellingPrice=899 ,Description="sadsasdsda",Year="2232"}
    });
            kernel.Bind<ICharacteristicRepository>().ToConstant(mock.Object);
        }
    }
}