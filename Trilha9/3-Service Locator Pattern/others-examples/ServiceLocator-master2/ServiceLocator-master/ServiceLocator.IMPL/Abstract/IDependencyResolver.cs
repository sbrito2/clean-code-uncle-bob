using System;
using System.Collections.Generic;

namespace ServiceLocator.IMPL.Abstract
{
    public interface IDependencyResolver
    {
        Type[] GetMethodDependencies(Type type, string methodName);
        Type[] GetMethodDependencies<T>(string methodName);
        Dictionary<string, Type> ResolveTypeDependencies(Type type);
        Dictionary<string, Type> ResolveTypeDependencies<T>();
        Type[][] GetConstructorDependencies(Type type);
        Type[][] GetConstructorDependencies<T>();

    }
}
