
using apiRESTful.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;

namespace apiRESTful.Controllers
{
    [Route("api/Customers")]
    public class CustomerController : Controller
    {
        readonly ICustomerService CustomerService;
        readonly IConfiguration config;
        readonly string path;

        public CustomerController(ICustomerService CustomerService, IConfiguration config)
        {
            this.CustomerService = CustomerService;

            this.path = config.GetValue<string>("keyPhrase");
            this.config = config;
        }

        [HttpGet]
        public IActionResult GetSection()
        {
            Ok(path);
        }

        [HttpGet]
        public IActionResult GetSection()
        {
            /*2-GetSection*/
            var constante = bool.Parse(config.GetSection("MySettings").GetSection("Parameters").Value); 

            Ok(constante);
        }

        // [HttpGet]
        // public IActionResult GetSectionAndValue()
        // {
        //     /*3-GetSection*/
        //      var constante = config.GetSection("MySettings").GetSection("Parameters").GetValue<bool>("IsProduction");; // here
             
        //      Ok(constante);
        // }

        // [HttpGet]
        // public IActionResult GetValueInline()
        // {
        //     /*4-GetSection*/
        //     var constante = config.GetValue<bool>("MySettings:Parameters:IsProduction");
            
        //     Ok(constante);
        // }

        // [HttpGet]
        // public IActionResult GetByOption()
        // {
        //     /*5-GetSection*/
        //     var constante = config.Value?.Parameters?.IsProduction ?? false;
            
        //     Ok(constante);
        // }

        // [HttpGet]
        // public bool GetByPreBindig
        // {
        //     /*6-GetSection*/
        //     var constante = _configuration.Value?.Parameters?.IsProduction ?? false;
        //      Ok(constante);
        // }
    }
}
