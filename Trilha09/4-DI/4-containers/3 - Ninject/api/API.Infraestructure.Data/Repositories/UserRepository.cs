using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infraestructure.Data.Context;
using System.Linq;
using API.Infraestructure.Data.Repositories.Base;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API.Domain.Queries;

namespace API.Infraestructure.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DomainContext context;
        public UserRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }

        public User GetUserByEmail(string email)
        {
            User user = this.context.Users.Where(u => u.Email == email).FirstOrDefault();
            return user;
        }

        public List<User> GetAllAndTheirProfile()
        {
            var users = this.context.Users.Include(x => x.Profile).ToList();

            return users;
        }

        public bool CheckEmailIsFree(string email)
        {
            return !this.context.Users.Any(x => x.Email.ToLower().Trim() == email.ToLower().Trim());
        }

        public PaginatedQueryResult<User> GetAll(GenericPaginatedQuery<string> query)
        {
            var users  = this.Query();

            var filteredUsers = ApplyFilter(users, query.Filter);

            return ApplyPagination(filteredUsers.ToList().OrderBy(x => x.Id).AsQueryable(), query);
        }

        private IQueryable<User> ApplyFilter(IQueryable<User> users, string filter)
        {
            if(filter == null)
            {
                return users;
            }

            var filteredByName = users.Where(w => w.Name.Trim().ToLower().Contains(filter.Trim().ToLower()));

            var filteredByCpf = users.Where(w => w.Cpf.Trim().ToLower().Contains(filter.Trim().ToLower()));

            var filteredByRg = users.Where(w => w.Rg.Trim().ToLower().Contains(filter.Trim().ToLower()));

            var filteredByEmail = users.Where(w => w.Email.Trim().ToLower().Contains(filter.Trim().ToLower()));
            
            var filteredUsers = filteredByName.Concat(filteredByCpf).Concat(filteredByRg).Concat(filteredByEmail);

            return filteredUsers;
        }
    }
}