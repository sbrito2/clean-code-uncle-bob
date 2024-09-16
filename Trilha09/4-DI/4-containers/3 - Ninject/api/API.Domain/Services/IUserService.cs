using API.Domain.Entities;
using API.Domain.Queries;
using API.Domain.Queries.Login;
using API.Domain.Queries.Login.Results;
using System.Collections.Generic;

namespace API.Domain.Services
{
    public interface IUserService : IService<User>
    {
        List<User> GetAll();
        PaginatedQueryResult<User> Index(int page, string filter);
        LoginQueryResult Authenticate(LoginQuery query);
    }
}
