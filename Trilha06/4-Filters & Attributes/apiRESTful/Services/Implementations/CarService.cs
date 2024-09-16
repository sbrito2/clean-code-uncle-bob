using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiRESTful.Interfaces;
using apiRESTful.Models;

namespace apiRESTful.Implementations
{
    public class CarService : ICarService
    {
        public async Task<Car> Add(Car car)
        {
            var context = new contextEntities();
            
            if(car == null)
            {
                return null;
            }

            context.Add(car);

            await context.SaveChangesAsync();

            return car;


        }

        public async Task<Car> Find(int id)
        {
            var context = new contextEntities();
            
            var coffe = await context.Car.FindAsync(id);

            return coffe;
        }

        public Task<List<Car>> GetAll()
        {
            var context = new contextEntities();
            
            var cars = context.Car.ToList();

            return Task.FromResult(cars);
        }

        public Task<Car> Update(Car car)
        {
            var context = new contextEntities();

            if(car == null)
            {
                context.Car.Update(car);
            }

            var response = context.Car.Any(x => x.CarId == car.CarId);
            if(!response)
            {
                return null;
            }
                
            context.SaveChangesAsync();

            return Task.FromResult(car);
        }

        public Task<bool> Delete(int id)
        {
            var context = new contextEntities();

            var car = context.Car.Find(id);
            if(car == null)
            {
                return Task.FromResult(false);
            }
            
            context.Remove(car);

            context.SaveChangesAsync();

            return Task.FromResult(true);
        }
    }
}