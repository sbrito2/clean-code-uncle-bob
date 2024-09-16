using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;
using API.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProductService productService;

        public ProdutoController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Createproduct([FromBody] Product product)
        {
            productService.Add(product);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult  GetAll()
        {
            var products = productService.GetAll();

            return Ok(products);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(int id)
        {
            var product = productService.Find(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut, Route("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            product.Id = id;

            productService.Update(product);

            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public IActionResult Delete(int id)
        {
            productService.Delete(id);

            return StatusCode(204); 
        }
    }
}
