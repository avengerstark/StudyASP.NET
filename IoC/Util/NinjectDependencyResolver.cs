using IoC.Context;
using Ninject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IoC.Util
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
            // Устанавливаем отношения между интерфейсами и их реализациями
            // Теперь при сопоставлении типов надо устанавливать аргумент, передаваемый в конструктор
            kernel.Bind<IRepository>().To<BookRepository>()
        .WithConstructorArgument("context", new BookContext());
        }
    }
}