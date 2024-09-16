using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using  API.CrossCutting.Utils.Response;
using API.Domain.Entities;

namespace API.Presentation.API.Controllers
{
    [ApiController]
    [Route("tests")]
    public class TestController : BaseController
    {
        public TestController()
        {
        }

        [HttpGet, Route("nullable-error")]
        public IActionResult  GetAll([FromQuery]string filter)
        {
            Property property = new Property();
            property.PropertyType.Type = "error";

            return Ok(property.AsSuccessResponse());
        }
    }
}