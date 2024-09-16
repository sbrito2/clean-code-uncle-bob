using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infra.Data.Repositories.Base;
using API.Infra.Data.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using API.Domain.Queries;

namespace API.Infra.Data
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly DomainContext context;
        public CustomerRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }

        public List<Customer> GetAllAndTheirChosenProperty()
        {
            var allCusomers = this.context.Customers
                .Include(x => x.Property);
            
            return allCusomers.ToList();
        }

        public PaginatedQueryResult<Customer> GetAll(GenericPaginatedQuery<string> query)
        {
            var customers  = this.Query().Include(x => x.Property);

            var filteredUsers = ApplyFilter(customers, query.Filter);

            return ApplyPagination(filteredUsers.ToList().OrderBy(x => x.Id).AsQueryable(), query);
        }

        private IQueryable<Customer> ApplyFilter(IQueryable<Customer> users, string filter)
        {
            if(filter == null)
            {
                return users;
            }

            var filteredByName = users.Where(w => w.Name.Trim().ToLower().Contains(filter.Trim().ToLower()));

            var filteredByEmail = users.Where(w => w.Email.Trim().ToLower().Contains(filter.Trim().ToLower()));

            var filteredByTelephone = users.Where(w => w.Telephone.Trim().ToLower().Contains(filter.Trim().ToLower()));
            
            var filteredCustomers = filteredByName.Concat(filteredByEmail).Concat(filteredByTelephone);

            return filteredCustomers;
        }
    }
}