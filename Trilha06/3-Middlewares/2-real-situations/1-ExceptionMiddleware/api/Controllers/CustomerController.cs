
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Interfaces;
using api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        readonly ICustomerService CustomerService;

        public CustomerController(ICustomerService CustomerService)
        {
            this.CustomerService = CustomerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody]CustomerRequestViewModel Customer)
        {
            if(Customer.CusName == null || Customer.CusCpf == null)
            {
                return BadRequest();
            }

            var request = new Customer()
            {
                CusName = Customer.CusName, 
                CarCpf = Customer.CusCpf
            };

            await CustomerService.Add(request);
          
            return StatusCode(201, request); 
        }


        [HttpGet]
        public async Task<IActionResult>  GetAll()
        {
            var customers = await CustomerService.GetAll();

            var models = customers.Select(x => new CustomerViewModel()
                {
                    CusId = x.CusId, 
                    CusName = x.CusName, 
                    CusCpf = x.CarCpf
                }
            ).ToList();

            return Ok(models);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]CustomerRequestViewModel Customer)
        {
            var request = new Customer()
            {
                CusName = Customer.CusName, 
                CarCpf = Customer.CusCpf
            };
            request.CusId = id;

            await CustomerService.Update(request);

            if(request == null)
            {
                return NotFound();
            }

            return Ok(Customer);
        }

        [HttpPatch, Route("{id}")]
        public async Task<IActionResult> Update(int id, string cpf)
        {

            var response = await CustomerService.UpdateCpf(id, cpf);

            if(!response)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await CustomerService.Delete(id);

            if(!response)
            {
                return NotFound();
            }

            return StatusCode(204); 
        }
    }
}
