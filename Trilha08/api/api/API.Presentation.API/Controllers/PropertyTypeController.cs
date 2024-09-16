using API.Domain.Entities;
using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using API.Presentation.API.ViewModels.ActionType;
using Microsoft.AspNetCore.Mvc;
using  API.Infra.Utils.Response;
using Microsoft.AspNetCore.Authorization;

namespace API.Presentation.API.Controllers
{
    [ApiController]
    [Route("propertyTypes")]
    public class PropertyTypeController : BaseController
    {
        readonly IPropertyTypeService propertyTypeService;
        public PropertyTypeController(IPropertyTypeService propertyTypeService)
        {
            this.propertyTypeService = propertyTypeService;
        }

        [HttpPost, Authorize]
        public IActionResult Create([FromForm]PropertyTypeRequestViewModel request)
        {
            var resourceType = Mapper.Map<PropertyType>(request);
            resourceType.UserId = GetUserId();

            var response = propertyTypeService.Add(resourceType);


            if(response == true)
                return StatusCode(201, response.AsSuccessResponse());

            return StatusCode(304); 
        }

        [HttpGet, Route("combo")]
        public IActionResult  GetAll()
        {
            var resources = propertyTypeService.GetAllComboboxForm();

            return Ok(resources.AsSuccessResponse());
        }
    }
}