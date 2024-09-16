using API.Domain.Entities;
using API.Domain.Queries;
using API.Domain.Queries.Login;
using API.Domain.Queries.Login.Results;
using API.Domain.Queries.Property;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Domain.Services
{
    public interface IUserService
    {
        bool Add(User user);
        List<User> GetAll();
        PaginatedQueryResult<User> Index(int page, string filter);
        User Find(int id);
        bool Update(User user);
        void Delete(int id);
        LoginQueryResult Authenticate(LoginQuery query);
    }
}
