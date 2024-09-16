

using System.Collections.Generic;
using API.Domain.Entities;
using API.Domain.Queries;

namespace API.Domain.Services
{
    public interface ICustomerService
    {
        bool Add(Customer user);
        PaginatedQueryResult<Customer> Index(int page, string filter);
        List<Customer> GetAll();
        Customer Find(int id);
        bool Update(Customer user);
        void Delete(int id);
    }
}
