using System.Net;
using api.Messages;
using api.Util.Enum;

namespace api.Response
{
    public class BaseResponse
    {
        public ResponseEnum Status { get; set; }
        public string Message { get; set; } 

        public BaseResponse(string message = null)
        {
            this.Status = ResponseEnum.Success;
            this.Message = message ?? ResponseMessages.Messages[HttpStatusCode.OK];
        }

        public T Success<T>(string message = null) where T : BaseResponse
        {
            this.Status = ResponseEnum.Success;
            this.Message = message ?? ResponseMessages.Messages[HttpStatusCode.OK];
            return (T)this;
        }

        public T Created<T>() where T : BaseResponse
        {
            this.Status = ResponseEnum.Created;
            this.Message = ResponseMessages.Messages[HttpStatusCode.Created];
            return (T)this;
        }

        public T NotFound<T>() where T : BaseResponse
        {
            this.Status = ResponseEnum.NotFound;
            this.Message = ResponseMessages.Messages[HttpStatusCode.NotFound];
            return (T)this;
        }

        public T Unauthorized<T>() where T : BaseResponse
        {
            this.Status = ResponseEnum.Unauthorized;
            this.Message = ResponseMessages.Messages[HttpStatusCode.Unauthorized];
            return (T)this;
        }

        public T BadRequest<T>(string message = null) where T : BaseResponse
        {
            this.Status = ResponseEnum.BadRequest;
            this.Message = message ?? ResponseMessages.Messages[HttpStatusCode.BadRequest];
            return (T)this;
        }

        public T InternalServerError<T>(string message = null) where T : BaseResponse
        {
            this.Status = ResponseEnum.InternalServerError;
            this.Message = message ?? ResponseMessages.Messages[HttpStatusCode.InternalServerError];
            return (T)this;
        }

        public T DbUpdateError<T>(string message = null) where T : BaseResponse
        {
            this.Status = ResponseEnum.InternalServerError;
            this.Message = message ?? ResponseMessages.Messages[HttpStatusCode.InternalServerError];
            return (T)this;
        }
    }
}