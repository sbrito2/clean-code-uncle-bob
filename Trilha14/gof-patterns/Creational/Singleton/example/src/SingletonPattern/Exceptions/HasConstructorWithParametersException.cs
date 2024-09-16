using System;

namespace Hes.Singleton.Exceptions {
    public sealed class HasConstructorWithParametersException : ConstructorException {
        private const string HasCtorWithParameters = "{0} has constructor(s) with parametersnstructor(s).";
        public HasConstructorWithParametersException(Type type) : base(type, string.Format(HasCtorWithParameters, type)) {
        }
    }
}