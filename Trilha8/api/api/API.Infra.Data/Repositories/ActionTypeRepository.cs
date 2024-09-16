using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infra.Data.Context;
using API.Infra.Data.Repositories.Base;

namespace API.Infra.Data
{
    public class ActionTypeRepository : Repository<ActionType>, IActionTypeRepository
    {
        private readonly DomainContext context;
        public ActionTypeRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }
    }
}