using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infra.Data.Context;
using API.Infra.Data.Repositories.Base;

namespace API.Infra.Data
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