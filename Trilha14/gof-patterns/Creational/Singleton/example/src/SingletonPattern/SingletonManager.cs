using System;
using System.Collections.Generic;
using Hes.Singleton.Exceptions;
using SingletonPattern.Attributes;

namespace SingletonPattern.Singleton {
    public class SingletonManager : SingletonBase<SingletonManager> {
        
        private readonly Dictionary<Type, Lazy<object>> _cache = new Dictionary<Type, Lazy<object>>();

        private SingletonManager() {
        }

        [NotThreadSafe]
        public void Register<T>() where T : SingletonBase<T> {
            if (_cache.ContainsKey(typeof(T))) {
                throw new AlreadyRegisteredTypeException(typeof(T));
            }
            _cache[typeof(T)] = new Lazy<object>(() => SingletonBase<T>.Instance);
        }

        [ThreadSafe]
        public T Get<T>() where T : SingletonBase<T> {
            if (_cache.TryGetValue(typeof(T), out var value)) {
                return (T)value.Value;
            }
            throw new NotRegisteredTypeException(typeof(T));
        }
    }
}