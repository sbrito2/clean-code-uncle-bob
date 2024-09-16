using ServiceLocator.IMPL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLocator.IMPL.Impl
{
    public class ObjectFactory : IObjectFactory
    {
        public virtual object Create(Type type, object[] args=null)
        {
            var parameterTypes = args.Select(arg => arg.GetType()).ToArray();
            var instance = type.GetConstructor(parameterTypes).Invoke(args);
            return instance;
        }

        public virtual T Create<T>(object[] args=null)
        {
            return (T) Create(typeof(T),args);
        }
    }
}
