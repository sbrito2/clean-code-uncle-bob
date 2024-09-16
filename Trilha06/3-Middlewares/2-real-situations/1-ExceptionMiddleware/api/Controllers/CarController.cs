
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Interfaces;
using api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers
{
    [Route("api/cars")]
    public class CarController : Controller
    {
        readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody]CarRequestViewModel car)
        {
            if(car.CarPlate == null)
            {
                return BadRequest();
            }

            var request = new Car()
            {
                CarPlate = car.CarPlate, 
                CarColor = car.CarColor, 
                CarModel = car.CarModel
            };

            await carService.Add(request);
          
            return StatusCode(201, request); 
        }


        [HttpGet]
        public async Task<IActionResult>  GetAll()
        {
            var cars = await carService.GetAll();

            var models = cars.Select(x => new CarViewModel()
                {
                    CarId = x.CarId, 
                    CarPlate = x.CarPlate, 
                    CarModel = x.CarModel, 
                    CarColor = x.CarColor
                }
            ).ToList();

            return Ok(models);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]CarRequestViewModel car)
        {
            var request = new Car()
            {
                CarPlate = car.CarPlate, 
                CarColor = car.CarColor, 
                CarModel = car.CarModel
            };
            request.CarId = id;

            await carService.Update(request);

            if(request == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await carService.Delete(id);

            if(!response)
            {
                return NotFound();
            }

            return StatusCode(204); 
        }
    }
}
