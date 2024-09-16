using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLocator.IMPL.Abstract
{
    public interface IServiceLocator
    {
        void Register(Type service, Type implementation);
        void Register<TService, TImplementation>();
        object Resolve(Type type);
        T Resolve<T>();
        bool CanResolve(Type type);
        bool CanResolve<T>();
        bool IsRegistered(Type type);
        bool IsRegistered<T>() where T : class;

    }
}
