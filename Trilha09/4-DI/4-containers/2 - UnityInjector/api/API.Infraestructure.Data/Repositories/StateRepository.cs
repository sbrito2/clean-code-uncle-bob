using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infraestructure.Data.Repositories.Base;
using API.Infraestructure.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace API.Infraestructure.Data
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        private readonly DomainContext context;
        public StateRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }

        public List<State> GetAll(string filter)
        {
            var states  = this.Query();

            var FilteredStates = ApplyFilter(states, filter);

            return FilteredStates.ToList();
        }

        private IQueryable<State> ApplyFilter(IQueryable<State> states, string filter)
        {
            if(filter == null)
            {
                return states;
            }

            return states.Where(x => x.Name.Trim().ToLower().Contains(filter.Trim().ToLower()));
        }
    }
}