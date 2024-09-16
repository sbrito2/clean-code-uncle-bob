using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace apiRESTful.Interfaces
{
    public interface ICarService
    {
        Task<Car> Add(Car car);
        Task<List<Car>> GetAll();
        Task<Car> Find(int id);
        Task<Car> Update(Car car);
        Task<bool> Delete(int id);
    }
}