

using System.Collections.Generic;
using API.Domain.Entities;
using API.Domain.Queries;

namespace API.Domain.Services
{
    public interface ICustomerService : IService<Customer>
    {
        PaginatedQueryResult<Customer> Index(int page, string filter);
        List<Customer> GetAll();
    }
}
