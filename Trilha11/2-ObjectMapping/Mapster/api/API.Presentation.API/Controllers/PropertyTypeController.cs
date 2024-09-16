using API.Domain.Entities;
using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using API.Presentation.API.ViewModels.ActionType;
using Microsoft.AspNetCore.Mvc;
using  API.CrossCutting.Utils.Response;
using Microsoft.AspNetCore.Authorization;
using API.Presentation.API.Configurations.Logger.ElasticSearch;
using Serilog;
using Mapster;

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
            var resourceType = request.Adapt<PropertyType>();
            
            resourceType.UserId = GetUserId();

            propertyTypeService.Add(resourceType);
            
            return StatusCode(201, true.AsSuccessResponse());
        }

        [HttpGet, Route("combo")]
        public IActionResult  GetAll()
        {
            var resources = propertyTypeService.GetAllComboboxForm();

            return Ok(resources.AsSuccessResponse());
        }
    }
}