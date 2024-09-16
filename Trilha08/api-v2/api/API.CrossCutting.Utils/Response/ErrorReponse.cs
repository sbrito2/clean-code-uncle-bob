using System.Net;

namespace API.CrossCutting.Utils.Response
{
    public class ErrorReponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public ErrorReponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}