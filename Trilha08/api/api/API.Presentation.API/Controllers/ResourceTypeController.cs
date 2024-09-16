
using API.Domain.Entities;
using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using API.Presentation.API.ViewModels.ResourceType;
using Microsoft.AspNetCore.Mvc;
using  API.Infra.Utils.Response;
using API.Presentation.API.Attributes;
using API.Domain.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace API.Presentation.API.Controllers
{
    [ApiController]
    [Route("resourceTypes")]
    public class ResouceTypeController : BaseController
    {
        readonly IResourceTypeService resourceTypeService;
        public ResouceTypeController(IResourceTypeService resourceTypeService)
        {
            this.resourceTypeService = resourceTypeService;
        }

        [HttpPost, Authorize]
        public IActionResult Create([FromForm]ResourceTypeRequestViewModel request)
        {
            var resourceType = Mapper.Map<ResourceType>(request);
            resourceType.UserId = GetUserId();

            var response = resourceTypeService.Add(resourceType);

            if(response == true)
                return StatusCode(201, response.AsSuccessResponse());

            return StatusCode(304); 
        }

        [HttpGet, Route("combo")]
        public IActionResult  GetAll()
        {
            var resources = resourceTypeService.GetAllComboboxForm();

            return Ok(resources.AsSuccessResponse());
        }
    }
}