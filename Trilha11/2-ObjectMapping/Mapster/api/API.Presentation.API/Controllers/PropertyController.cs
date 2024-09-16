
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Entities;
using API.Domain.Queries;
using API.Domain.Queries.Property;
using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using API.Presentation.API.ViewModels.Property;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using  API.CrossCutting.Utils.Response;
using API.Presentation.API.Attributes;
using API.Domain.Permissions;
using Mapster;

namespace API.Presentation.API.Controllers
{
    [ApiController]
    [Route("properties")]
    public class PropertyController : BaseController
    {
        readonly IPropertyService propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }
        
        [HttpPost, DisableRequestSizeLimit, Authorize]
        public IActionResult CreateProperty([FromForm]PropertyRequestViewModel propertyRequest)
        {
            var property = propertyRequest.Adapt<Property>();
    
            property.UserId = GetUserId();

            propertyService.Add(property, propertyRequest.photos);

            return StatusCode(201, true.AsSuccessResponse());
        }

        [HttpGet]
        public IActionResult  GetAll()
        {
            var propertiess = propertyService.GetAll();

            var response = propertiess.Select(x => x.Adapt<PropertyResponseViewModel>()).ToList();

            return Ok(response.AsSuccessResponse());
        }

        [HttpGet, Route("get-random-properties")]
        public IActionResult  GetRandomProperties()
        {
            var propertiess = propertyService.GetRandomProperties();

            var response = propertiess.Select(x => x.Adapt<PropertyViewModel>()).ToList();

            return Ok(response.AsSuccessResponse());
        }

        [HttpGet, Route("index")]
        public IActionResult  Index([FromQuery]PropertyQuery filter, [FromQuery] int page)
        {
            var properties = propertyService.Index(page, filter);
            var propertiesResponse = properties.Transform(employee => employee.Adapt<PropertyResponseViewModel>());

            return Ok(propertiesResponse);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(int id)
        {
            var property = propertyService.Find(id);

            var propertyViewModel = property.Adapt<PropertyResponseViewModel>();

            return Ok(propertyViewModel.AsSuccessResponse());
        }

        [HttpPut, Route("{id}"), Authorize]
        public IActionResult Update(int id, [FromForm]PropertyRequestViewModel request)
        {
            var property = request.Adapt<Property>();
 
            property.Id = id;
            property.UserId = GetUserId();

            propertyService.Update(property, request.photos);

            return Ok();
        }

        [HttpDelete, Route("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            propertyService.Delete(id);

            return StatusCode(204); 
        }

        [HttpGet, Route("relatorio.csv"), Produces("text/csv")]
        [AllowAnonymous]
        public IActionResult  GetAllCsv()
        {
            var propertiess = propertyService.GetAll();

            var response = propertiess.Select(x => x.Adapt<PropertyResponseViewModel>()).ToList();

            return Ok(new FileResponse(response));
        }

        [HttpGet, AllowAnonymous]
        [Route("web-image/{id}/{fileName}")]
        public IActionResult GetWebImage(int id, string fileName)
        {
            var bytes = propertyService.GetImage(id, fileName);

            return File(bytes, "image/png");
        }
    }
}