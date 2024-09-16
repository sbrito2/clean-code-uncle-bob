
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;

namespace api.Controllers
{
    [Route("api/tests")]
    public class TestController : Controller
    {

        public TestController()
        {
        }

        [HttpGet, Route("test-exception-middleware")]
        public IActionResult  TestBadRequestException()
        {
            throw new Exception("erro");
        }
    }
}
