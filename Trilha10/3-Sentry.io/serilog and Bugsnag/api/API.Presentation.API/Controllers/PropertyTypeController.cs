using API.Domain.Entities;
using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using API.Presentation.API.ViewModels.ActionType;
using Microsoft.AspNetCore.Mvc;
using  API.CrossCutting.Utils.Response;
using Microsoft.AspNetCore.Authorization;
using Mindscape.Raygun4Net.AspNetCore;
using System;

namespace API.Presentation.API.Controllers
{
    [ApiController]
    [Route("propertyTypes")]
    public class PropertyTypeController : BaseController
    {
        readonly IPropertyTypeService propertyTypeService;
        private readonly Bugsnag.IClient _bugsnag;
        public PropertyTypeController(IPropertyTypeService propertyTypeService, Bugsnag.IClient clien)
        {
            this.propertyTypeService = propertyTypeService;
        }

        [HttpPost, Authorize]
        public IActionResult Create([FromForm]PropertyTypeRequestViewModel request)
        {
            var resourceType = Mapper.Map<PropertyType>(request);
            resourceType.UserId = GetUserId();

            propertyTypeService.Add(resourceType);
            
            return StatusCode(201, true.AsSuccessResponse());
        }

        [HttpGet, Route("combo")]
        public IActionResult  GetAll()
        {
            _bugsnag.Notify(new Exception("Test error"));

            var resources = propertyTypeService.GetAllComboboxForm();

            return Ok(resources.AsSuccessResponse());
        }
    }
}