using ServiceLocator.IMPL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLocator.IMPL.Impl
{
    public class ServiceLocatorImpl : IServiceLocator
    {
        private readonly Dictionary<Type, List<Type>> _serviceCache = new Dictionary<Type, List<Type>>();
        private readonly IObjectFactory _objectFactory;
        private readonly IDependencyResolver _dependencyResolver;
        public ServiceLocatorImpl(IObjectFactory objectFactory, IDependencyResolver dependencyResolver)
        {
            _objectFactory = objectFactory;
            _dependencyResolver = dependencyResolver;
        }
        public void Register(Type service, Type implementation)
        {
            var cache = _serviceCache.FirstOrDefault(services => services.Key == service).Value;
            if (cache==null)
            {
                cache = new List<Type>();
                _serviceCache.Add(service, cache);
            }
            cache.Add(implementation);
        }

        public void Register<TService, TImplementation>()
        {
            Register(typeof(TService), typeof(TImplementation));
        }

        public object Resolve(Type type)
        {
            var t = _serviceCache.FirstOrDefault(services => services.Key == type).Value.FirstOrDefault();
            if (t == null)
            {
                throw new Exception("type is not registered");
            }
            var dependencies = _dependencyResolver.GetConstructorDependencies(t).FirstOrDefault()
               .Select(dependencyType => Resolve(dependencyType)).ToArray();

            var result = _objectFactory.Create(t,dependencies);
            return result;
        }

        public T Resolve<T>()
        {
            var result = Resolve(typeof(T));
            return (T) result;
        }
        public bool CanResolve(Type type)
        {
            if (type.IsInterface)
            {
                throw new ArgumentException("type argument must be an interface type");
            }
            var result = _serviceCache.Keys.Contains(type); 
          
            return result;
        }
        public bool CanResolve<T>() 
        {
            var result = CanResolve(typeof(T));
            return result;
        }
        public bool IsRegistered(Type type)
        {
            if(!type.IsClass)
            {
                throw new ArgumentException("type argument must be an class type");
            }
            var result = _serviceCache.Any(item => item.Value.Contains(type));
            return result;
        }
        public bool IsRegistered<T>() where T : class
        {
            var result = IsRegistered(typeof(T));
            return result;
        }
    }
}
