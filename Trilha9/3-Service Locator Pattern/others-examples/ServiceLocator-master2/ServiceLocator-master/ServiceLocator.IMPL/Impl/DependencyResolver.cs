using ServiceLocator.IMPL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLocator.IMPL.Impl
{
    public class DependencyResolver : IDependencyResolver
    {
        public Type[][] GetConstructorDependencies(Type type)
        {
            var result = type.GetConstructors().Select(constructor => constructor.GetParameters().Select(parameter => parameter.ParameterType).ToArray()).ToArray();
            return result;
        }

        public Type[][] GetConstructorDependencies<T>()
        {
            var result = GetConstructorDependencies(typeof(T));
            return result;
        }

        public Type[] GetMethodDependencies(Type type, string methodName)
        {
            var result = type.GetMethod(methodName).GetParameters().Select(parameter => parameter.ParameterType).ToArray();
            return result;
        }
        public Type[] GetMethodDependencies<T>(string methodName)
        {
            var result = GetMethodDependencies(typeof(T), methodName);
            return result;
        }
        public Dictionary<string, Type> ResolveTypeDependencies(Type type)
        {
            var result = new Dictionary<string, Type>();
            type.GetMembers(System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.GetProperty).ToList().ForEach(field => result.Add(field.Name, field.ReflectedType));
            return result;
        }

        public Dictionary<string, Type> ResolveTypeDependencies<T>()
        {
            var result = ResolveTypeDependencies(typeof(T));
            return result;
        }
    }
}
