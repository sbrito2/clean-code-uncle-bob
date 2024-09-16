using System;

namespace SingletonPattern.Attributes {
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Class)]
    public class ThreadSafeAttribute : Attribute {

    }
}