using System;
using System.Runtime.Serialization;

namespace API.CrossCutting.Utils.Security.Exceptions
{
    [Serializable]
    public class BadRequesttException : Exception
    {
        protected BadRequesttException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
           
        }
        public BadRequesttException(string message) : base(message)
        {
        }
    }
}
