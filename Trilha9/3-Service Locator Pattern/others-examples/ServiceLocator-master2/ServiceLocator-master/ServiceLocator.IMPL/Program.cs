using ServiceLocator.IMPL.Impl;
using ServiceLocator.IMPL.Model;
using System;

namespace ServiceLocator.IMPL
{
    class Program
    {
        static void Main(string[] args)
        {
            //var factory = new ObjectFactory();
            //var instance = factory.Create<Man>();
            var serviceLocator = new ServiceLocatorImpl(new ObjectFactory(), new DependencyResolver());
            serviceLocator.Register<IHuman, Woman>();
            serviceLocator.Register<IHuman, Man>();
            var human = serviceLocator.Resolve<IHuman>();


        }
    }

}
