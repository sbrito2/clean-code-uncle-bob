

using API.Domain.CoreLogic.Entities;
using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using API.Presentation.API.ViewModels.ActionType;
using Microsoft.AspNetCore.Mvc;
using  API.CrossCutting.Utils.Response;
using Microsoft.AspNetCore.Authorization;

namespace API.Presentation.API.Controllers
{
    [ApiController]
    [Route("actionTypes")]
    public class ActionTypeController : BaseController
    {
        readonly IActionTypeService actionTypeService;
        public ActionTypeController(IActionTypeService actionTypeService)
        {
            this.actionTypeService = actionTypeService;
        }

        [HttpPost, Authorize]
        public IActionResult Create([FromForm]ActionTypeRequestViewModel request)
        {
            var resourceType = Mapper.Map<ActionType>(request);
            resourceType.UserId = GetUserId();

            actionTypeService.Add(resourceType);

            return StatusCode(201, true.AsSuccessResponse());
        }

        [HttpGet, Route("combo")]
        public IActionResult  GetAll()
        {
            var resources = actionTypeService.GetAllComboboxForm();

            return Ok(resources.AsSuccessResponse());
        }
    }
}