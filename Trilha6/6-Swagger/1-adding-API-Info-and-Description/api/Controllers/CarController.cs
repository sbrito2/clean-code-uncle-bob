
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using apiRESTful.Interfaces;
using apiRESTful.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apiRESTful.Controllers
{
    [Route("api/cars")]
    public class CarController : Controller
    {
        readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        /// <summary>
        /// Add a new car to the store
        /// </summary>
        
        /// <param name="body">Car object that needs to be added to the store</param>
        /// <response code="203">Created</response>
        /// <response code="405">Invalid input</response>
        // [ValidateModelState]
        // [SwaggerOperation("AddCar")]

        [HttpPost]
        [SwaggerResponse(200, "Successfully created the car", typeof(Car))]
        public async Task<IActionResult> AddCar(CarRequestViewModel car)
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

        /// <summary>
        /// Get all car fron the store
        /// </summary>

        /// <response code="200">success</response>
        // // [ValidateModelState]
        // [SwaggerOperation("UpdateCar")]

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

        /// <summary>
        /// Update an existing car
        /// </summary>
        
        /// <param name="body">Car object that needs to be added to the store</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Car not found</response>
        /// <response code="405">Validation exception</response>
        // [ValidateModelState]
        // [SwaggerOperation("UpdateCar")]

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update(int id, CarRequestViewModel car)
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

        /// <summary>
        /// Deletes a car
        /// </summary>
        
        /// <param name="petId">Car id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Pet not found</response>
        // [ValidateModelState]
        // [SwaggerOperation("DeleteCar")]

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
