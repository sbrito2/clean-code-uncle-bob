using System.Net;

namespace API.Domain.Notification
{
    public class Notification
    {
        public HttpStatusCode Code { get; private set; }
        public string Message { get; set; } 

        public Notification(HttpStatusCode code, string message)
        {
            Code = code;
            Message = message;
        }

        public Notification(string message = null)
        {
            Code = HttpStatusCode.BadRequest;
            Message = message;
        }

        public T InexistentId<T>(string message) where T : Notification
        {
            this.Code = HttpStatusCode.NotFound;
            this.Message = message;
            return (T)this;
        }

        public T NullError<T>(string message = null) where T : Notification
        {
            this.Code = HttpStatusCode.Conflict;
            this.Message = message;
            return (T)this;
        }
    }
}