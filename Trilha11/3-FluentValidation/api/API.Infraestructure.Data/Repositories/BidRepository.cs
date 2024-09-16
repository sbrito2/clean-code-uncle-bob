using API.Domain.CoreLogic.Entities;
using API.Domain.Repositories;
using API.Infraestructure.Data.Context;
using API.Infraestructure.Data.Repositories.Base;

namespace API.Infraestructure.Data
{
    public class BidRepository : Repository<Bid>, IBidRepository
    {
        private readonly DomainContext context;
        public BidRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }
    }
}