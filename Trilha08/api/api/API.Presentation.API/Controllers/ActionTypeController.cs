

using API.Domain.Entities;
using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using API.Presentation.API.ViewModels.ActionType;
using Microsoft.AspNetCore.Mvc;
using  API.Infra.Utils.Response;
using API.Presentation.API.Attributes;
using API.Domain.Permissions;
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

            var response = actionTypeService.Add(resourceType);

            if(response == true)
                return StatusCode(201, response.AsSuccessResponse());

            return StatusCode(304); 
        }

        [HttpGet, Route("combo")]
        public IActionResult  GetAll()
        {
            var resources = actionTypeService.GetAllComboboxForm();

            return Ok(resources.AsSuccessResponse());
        }
    }
}