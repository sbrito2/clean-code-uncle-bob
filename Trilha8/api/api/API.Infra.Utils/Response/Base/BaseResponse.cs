
using API.Infra.Utils.Response.Messages;

namespace API.Infra.Utils.Response.Base
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public BaseResponse()
        {
            this.Message = ResponseMessages.Messages[ResponseStatus.Success];
        }

        public T Success<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatus.Success];
            return (T)this;
        }

        public T NotFound<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatus.NotFound];
            return (T)this;
        }

        public T InternalServerError<T>() where T : BaseResponse
        {
            this.Message = ResponseMessages.Messages[ResponseStatus.Error];
            return (T)this;
        }

        public T Error<T>(string message) where T : BaseResponse
        {
            this.Message = message;
            return (T)this;
        }

        public T NoModifield<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatus.NoModified];
            return (T)this;
        }

        public T BadRequest<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatus.BadRequest];
            return (T)this;
        }

        public T UnprocessableRequest<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatus.Unprocessable];
            return (T)this;
        }

        public T Forbidden<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatus.Forbidden];
            return (T)this;
        }
        
        public T Unauthorized<T>(string message = null) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatus.Unauthorized];
            return (T)this;
        }

        public T Conflict<T>(string message) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatus.Conflict];
            return (T)this;
        }

        public T File<T>(string message) where T : BaseResponse
        {
            this.Message = message ?? ResponseMessages.Messages[ResponseStatus.Conflict];
            return (T)this;
        }
    }
}
