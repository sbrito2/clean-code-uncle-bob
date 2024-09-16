using System.Linq;
using API.Domain.Entities;
using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using API.Presentation.API.ViewModels.Customer;
using API.Presentation.API.ViewModels.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using  API.Infra.Utils.Response;
using API.Presentation.API.Attributes;
using API.Domain.Permissions;
using API.Domain.Projections.Email;

namespace API.Presentation.API.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : BaseController
    {
        readonly ICustomerService customerService;
        readonly IEmailService emailService;
        public CustomerController(ICustomerService customerService, IEmailService emailService)
        {
            this.customerService = customerService;
            this.emailService = emailService;
        }
        
        [HttpPost, AllowAnonymous]
        public IActionResult CreateCustomer([FromBody]CustomerRequestViewModel userRequest)
        {
            var customer = Mapper.Map<Customer>(userRequest);
            var response = customerService.Add(customer);

            if(response == true)
                return StatusCode(201, response.AsSuccessResponse());

            return StatusCode(304); 
        }

        [HttpGet, Route("index")]
        public IActionResult  Index([FromQuery]int page, [FromQuery]string filter)
        {
            var customers = customerService.Index(page, filter);

            var response = customers.Transform(customer => Mapper.Map<CustomerResponseViewModel>(customer));

            return Ok(response.AsSuccessResponse());
        }

        [HttpPut, Route("{id}"), Authorize]
        public IActionResult Update(int id, [FromBody]CustomerRequestViewModel request)
        {
            var customer = Mapper.Map<Customer>(request);
            customer.Id = id;

            var response = customerService.Update(customer);

            if(!response)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete, Route("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            customerService.Delete(id);

            return StatusCode(204); 
        }

        [HttpGet, Route("relatorio.csv"), Produces("text/csv")]
        [Authorize]
        public IActionResult  GetAllCsv()
        {
            var propertiess = customerService.GetAll();

            var response = propertiess.Select(Mapper.Map<CustomerResponseViewModel>).ToList();

            return Ok(new FileResponse(response));
        }

        [HttpPost, Route("send-email")]
        public IActionResult SendEmail(EmailViewModel request)
        {
            var customerEmail = Mapper.Map<EmailProjectionModel>(request);

            emailService.SendCustomerEmail(customerEmail);

            return Ok(); 
        }
    }
}