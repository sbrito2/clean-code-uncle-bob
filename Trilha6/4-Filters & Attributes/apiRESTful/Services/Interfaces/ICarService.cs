using System.Collections.Generic;
using System.Threading.Tasks;
using apiRESTful.Models;

namespace apiRESTful.Interfaces
{
    public interface ICarService
    {
        Task<Car> Add(Car coffe);
        Task<List<Car>> GetAll();
        Task<Car> Find(int id);
        Task<Car> Update(Car coffe);
        Task<bool> Delete(int id);
    }
}