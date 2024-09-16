
using System.Runtime.CompilerServices;
using System.Linq;
using System.Threading.Tasks;
using api.Implementations;
using api.Interfaces;
using api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace apiRESTful.Controllers
{
    [Route("api/tests")]
    public class TestController : Controller
    {

        public TestController()
        {
        }


        [HttpGet, Route("SwaggerOperation")]
        [SwaggerOperation("TestOperator2")]
        public IActionResult  TestOperator()
        {
            return Ok("Operator 1");
        }

        
        [HttpGet, Route("SwaggerOperation2")]
        public IActionResult  TestOperator2()
        {
            return Ok("Operador 2");
        }
    }
}
