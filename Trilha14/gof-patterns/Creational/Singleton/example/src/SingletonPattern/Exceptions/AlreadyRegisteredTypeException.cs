using System;
using SingletonPattern.Singleton;

namespace Hes.Singleton.Exceptions {
    public class AlreadyRegisteredTypeException : Exception {
        public AlreadyRegisteredTypeException(Type type):base($"{type.FullName} is already registered at {typeof(SingletonManager)}.") {
            
        }
    }
}