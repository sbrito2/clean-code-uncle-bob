using System;
using System.Runtime.Serialization;

namespace API.Infra.Utils.Security.Exceptions
{
    [Serializable]
    public class ForbidException : Exception
    {
        protected ForbidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
           
        }
        public ForbidException(string message) : base(message)
        {
        }
    }
}