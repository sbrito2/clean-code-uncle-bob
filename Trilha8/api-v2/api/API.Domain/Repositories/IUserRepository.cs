using System.Collections.Generic;
using System.Linq;
using API.Domain.Entities;
using API.Domain.Queries;
using API.Domain.Repositories.Base;

namespace API.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
        List<User> GetAllAndTheirProfile();
        bool CheckEmailIsFree(string email);
        PaginatedQueryResult<User> GetAll(GenericPaginatedQuery<string> query);
    }
}