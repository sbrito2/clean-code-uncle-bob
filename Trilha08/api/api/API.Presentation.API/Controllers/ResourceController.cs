
using System.Collections.Generic;
using System.Linq;

using API.Domain.Entities;
using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using  API.Infra.Utils.Response;
using API.Presentation.API.ViewModels.Resource;
using Microsoft.AspNetCore.Authorization;

namespace API.Presentation.API.Controllers
{
    [ApiController]
    [Route("resources")]
    public class ResourceController : BaseController
    {
        readonly IResourceService resourceService;
        public ResourceController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }
        

        [HttpPost, Authorize]
        public IActionResult Create([FromForm]ResourceRequestViewModel propertyRequest)
        {
            var resource = Mapper.Map<Resource>(propertyRequest);
            resource.UserId = GetUserId();

            var response = resourceService.Add(resource);

            if(response == true)
                return StatusCode(201, response.AsSuccessResponse());

            return StatusCode(304); 
        }

        [HttpGet, Route("{propertyId}")]
        public IActionResult  GetAllByProperty(int propertyId)
        {
            var resources = resourceService.GetAllByProperty(propertyId);

            return Ok(resources.AsSuccessResponse());
        }
    }
}