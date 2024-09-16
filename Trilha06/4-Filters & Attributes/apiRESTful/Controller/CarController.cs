
using System.Linq;
using System.Threading.Tasks;
using apiRESTful.Implementations;
using apiRESTful.Models;
using apiRESTful.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace apiRESTful.Controllers
{
    [Route("api/cars")]
    public class CarController : Controller
    {
        public CarController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarRequestViewModel car)
        {
            if(car.CarPlate == null)
            {

            }

            var request = new Car(){CarPlate = car.CarPlate, CarColor = car.CarColor, CarModel = car.CarModel};

            var carService = new CarService();
            await carService.Add(request);
          
            return StatusCode(201); 
        }

        [HttpGet]
        public async Task<IActionResult>  GetAll()
        {
            var carService = new CarService();
            var cars = await carService.GetAll();

            var models = cars.Select(x => new CarViewModel(){CarId = x.CarId, CarPlate = x.CarPlate, CarModel = x.CarModel, CarColor = x.CarColor}).ToList();

            return Ok(models);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, CarRequestViewModel car)
        {
            var request = new Car(){CarPlate = car.CarPlate, CarColor = car.CarColor, CarModel = car.CarModel};
            request.CarId = id;

            var carService = new CarService();
            await carService.Update(request);

            if(request == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var carService = new CarService();
            var response = await carService.Delete(id);

            if(!response)
            {
                return NotFound();
            }

            return StatusCode(204); 
        }
    }
}
