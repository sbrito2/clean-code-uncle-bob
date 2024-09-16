using System;

namespace SingletonPattern.Attributes {
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class NotThreadSafeAttribute : Attribute {
      
    }
}