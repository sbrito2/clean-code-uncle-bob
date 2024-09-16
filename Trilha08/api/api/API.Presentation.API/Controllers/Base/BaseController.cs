using API.Infra.Utils.Response;
using API.Infra.Utils.Response.Base;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace API.Presentation.API.Controllers.Base
{
    [ApiController]
    public class BaseController : Controller
    {
        protected IMapper Mapper;
        public BaseController()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            SetMapper();
            base.OnActionExecuting(context);
        }

        protected void SetMapper()
        {
            Mapper = (IMapper)HttpContext.RequestServices.GetService(typeof(IMapper));
        }

        protected int GetUserId()
        {
            var userId = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId");

            if (userId == null) return 0;

            return int.Parse(this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
        }
 
        protected bool IsAdmUser()
        {
            var profileId = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "ProfileId");
            if (profileId == null) return false;

            var profile = int.Parse(this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "ProfileId").Value.ToString());

            if (profile == 1)
                return true;

            return false;
        }

        public override OkObjectResult Ok(object result)
        {
            if (result is FileResponse)
            {
                FileResponse value = (FileResponse)result;
                return base.Ok(value.File);
            }

            if (!(result is BaseResponse))
            {
                return base.Ok(result.AsSuccessResponse());
            }

            return base.Ok(result);
        }
    }
}