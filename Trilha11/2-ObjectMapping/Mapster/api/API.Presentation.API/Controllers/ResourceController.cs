
using System.Collections.Generic;
using System.Linq;
using API.Domain.Entities;
using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using  API.CrossCutting.Utils.Response;
using API.Presentation.API.ViewModels.Resource;
using Microsoft.AspNetCore.Authorization;
using Mapster;

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
            var resource = propertyRequest.Adapt<Resource>();
   
            resource.UserId = GetUserId();

            resourceService.Add(resource);

            return StatusCode(201, true.AsSuccessResponse()); 
        }

        [HttpGet, Route("{propertyId}")]
        public IActionResult  GetAllByProperty(int propertyId)
        {
            var resources = resourceService.GetAllByProperty(propertyId);

            return Ok(resources.AsSuccessResponse());
        }
    }
}