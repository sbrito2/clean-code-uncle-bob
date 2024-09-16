using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infraestructure.Data.Context;
using API.Infraestructure.Data.Repositories.Base;

namespace API.Infraestructure.Data
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