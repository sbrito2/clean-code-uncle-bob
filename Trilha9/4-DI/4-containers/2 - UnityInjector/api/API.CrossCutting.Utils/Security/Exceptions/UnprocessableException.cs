using System;
using System.Runtime.Serialization;

namespace API.CrossCutting.Utils.Security.Exceptions
{
    [Serializable]
    public class UnprocessableException : Exception
    {
        protected UnprocessableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
           
        }
        public UnprocessableException(string message) : base(message)
        {
        }
    }
}
