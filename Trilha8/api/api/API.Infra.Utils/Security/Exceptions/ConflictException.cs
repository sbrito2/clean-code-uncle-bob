using System;
using System.Runtime.Serialization;

namespace API.Infra.Utils.Security.Exceptions
{
    [Serializable]
    public class ConflictException : Exception
    {
        protected ConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
           
        }
        public ConflictException(string message) : base(message)
        {
        }
    }
}
