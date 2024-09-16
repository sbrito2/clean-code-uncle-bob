using System;
using System.Runtime.Serialization;

namespace API.Infra.Utils.Security.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
           
        }
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
