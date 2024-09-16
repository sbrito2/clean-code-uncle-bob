using System;

namespace Hes.Singleton.Exceptions {
    public abstract class ConstructorException : Exception {
        private const string ExpectedTohave = "{0} {1} is expected to have only non-public parameterless constructor.";

        protected ConstructorException(Type type, string message) : base(string.Format(ExpectedTohave, message, type)) {
        }
    }
}