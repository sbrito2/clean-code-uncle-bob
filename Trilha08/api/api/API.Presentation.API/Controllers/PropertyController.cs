
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
using  API.Infra.Utils.Response;
using API.Presentation.API.Attributes;
using API.Domain.Permissions;

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
            var property = Mapper.Map<Property>(propertyRequest);
            property.UserId = GetUserId();

            var response = propertyService.Add(property, propertyRequest.photos);

            if(response == true)
                return StatusCode(201, response.AsSuccessResponse());

            return StatusCode(304); 
        }

        [HttpGet]
        public IActionResult  GetAll()
        {
            var propertiess = propertyService.GetAll();

            var response = propertiess.Select(Mapper.Map<PropertyResponseViewModel>).ToList();

            return Ok(response.AsSuccessResponse());
        }

        [HttpGet, Route("get-random-properties")]
        public IActionResult  GetRandomProperties()
        {
            var propertiess = propertyService.GetRandomProperties();

            var response = propertiess.Select(Mapper.Map<PropertyViewModel>).ToList();

            return Ok(response.AsSuccessResponse());
        }

        [HttpGet, Route("index")]
        public IActionResult  Index([FromQuery]PropertyQuery filter, [FromQuery] int page)
        {
            var properties = propertyService.Index(page, filter);
            var propertiesResponse = properties.Transform(employee => Mapper.Map<PropertyResponseViewModel>(employee));

            return Ok(propertiesResponse);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(int id)
        {
            var property = propertyService.Find(id);

            if(property == null)
            {
                return NotFound();
            }

            var propertyViewModel = Mapper.Map<PropertyResponseViewModel>(property);

            return Ok(propertyViewModel.AsSuccessResponse());
        }

        [HttpPut, Route("{id}"), Authorize]
        public IActionResult Update(int id, [FromForm]PropertyRequestViewModel request)
        {
            var property = Mapper.Map<Property>(request);
            property.Id = id;
            property.UserId = GetUserId();

            var response = propertyService.Update(property, request.photos);

            if(!response)
            {
                return NotFound();
            }

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

            var response = propertiess.Select(Mapper.Map<PropertyResponseViewModel>).ToList();

            return Ok(new FileResponse(response));
        }

        [HttpGet, AllowAnonymous]
        [Route("image/{id}/{fileName}/web")]
        public IActionResult GetWebImage(int id, string fileName)
        {
            if (Mapper == null) SetMapper();

            var bytes = propertyService.GetImage(id, fileName);
            if (bytes == null)
            {
                return NotFound();
            }

            return File(bytes, "image/png");
        }
    }
}