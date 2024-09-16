using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace apiRESTful.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Add(Customer Customer);
        Task<List<Customer>> GetAll();
        Task<Customer> Find(int id);
        Task<Customer> Update(Customer Customer);
        Task<bool> Delete(int id);
    }
}