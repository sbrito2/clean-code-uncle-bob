using System.Net;

namespace API.CrossCutting.Utils.Response.Messages
{
    public enum ResponseStatus
    {
        Success = HttpStatusCode.OK,
        Created = 201,
        Error = 500,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        NoModified = HttpStatusCode.NotModified,
        Unprocessable = 402,
        Forbidden = HttpStatusCode.Forbidden,
        Conflict = HttpStatusCode.Conflict
    }
}
