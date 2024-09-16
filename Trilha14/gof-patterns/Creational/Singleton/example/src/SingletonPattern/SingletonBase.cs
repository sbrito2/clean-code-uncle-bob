using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Hes.Singleton.Exceptions;
using SingletonPattern.Attributes;

namespace SingletonPattern.Singleton {
    public abstract class SingletonBase<T> {
        
        private static readonly Lazy<T> LazyInstance = new Lazy<T>(InstanceCreator);
        private static int _instanceCount;

        protected SingletonBase() {
            Interlocked.Increment(ref _instanceCount);
            if (_instanceCount > 1) {
                throw new Exception($"{nameof(T)} is Singleton but it has {_instanceCount} instances");
            }
        }

        [ThreadSafe]
        public static T Instance => LazyInstance.Value;
        private static T InstanceCreator() {
            var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var publicCtors = ctors.Where(c => c.IsPublic);
            if (publicCtors.Any()) {
                throw new HasPublicConstructorException(typeof(T));
            }

            var ctorsWithParameters = ctors.Where(c => c.GetParameters().Length > 0);
            if (ctorsWithParameters.Any()) {
                throw new HasConstructorWithParametersException(typeof(T));
            }

            return (T) Activator.CreateInstance(typeof(T), true);
        }
    }
}