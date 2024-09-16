using System;

namespace Hes.Singleton.Exceptions {
    public sealed class HasPublicConstructorException : ConstructorException {
       
        private const string HasPublicCtor = "{0} has public constructor(s).";
        public HasPublicConstructorException(Type type) : base(type, string.Format(HasPublicCtor, type.FullName)) {
        }
    }
}