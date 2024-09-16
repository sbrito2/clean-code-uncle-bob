using System.Collections.Generic;
using System.Linq;
using API.Domain.Entities;
using API.Domain.Queries;
using API.Domain.Repositories.Base;

namespace API.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<Customer> GetAllAndTheirChosenProperty();
        PaginatedQueryResult<Customer> GetAll(GenericPaginatedQuery<string> query);
    }
}