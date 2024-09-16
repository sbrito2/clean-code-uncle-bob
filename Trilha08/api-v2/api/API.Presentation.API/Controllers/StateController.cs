using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using  API.CrossCutting.Utils.Response;

namespace API.Presentation.API.Controllers
{
    [ApiController]
    [Route("states")]
    public class StateController : BaseController
    {
        readonly IStateService stateService;
        public StateController(IStateService stateService)
        {
            this.stateService = stateService;
        }

        [HttpGet, Route("combo")]
        public IActionResult  GetAll([FromQuery]string filter)
        {
            var resources = stateService.GetAllComboboxForm(filter);

            return Ok(resources.AsSuccessResponse());
        }
    }
}