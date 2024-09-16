using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infra.Data.Context;
using API.Infra.Data.Repositories.Base;

namespace API.Infra.Data
{
    public class ActionRepository : Repository<Action>, IActionRepository
    {
        private readonly DomainContext context;
        public ActionRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }
    }
}