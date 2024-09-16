using API.Domain.CoreLogic.Entities;
using API.Domain.Repositories;
using API.Infraestructure.Data.Context;
using API.Infraestructure.Data.Repositories.Base;

namespace API.Infraestructure.Data
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