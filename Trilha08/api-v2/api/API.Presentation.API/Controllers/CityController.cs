using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using  API.CrossCutting.Utils.Response;

namespace API.Presentation.API.Controllers
{
    [ApiController]
    [Route("cities")]
    public class CityController : BaseController
    {
        readonly ICityService cityService;
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet, Route("combo")]
        public IActionResult  GetAll([FromQuery]string filter)
        {
            var resources = cityService.GetAllComboboxForm(filter);

            return Ok(resources.AsSuccessResponse());
        }
    }
}