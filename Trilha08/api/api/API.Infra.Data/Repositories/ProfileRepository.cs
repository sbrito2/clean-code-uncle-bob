using API.Domain.Entities;
using API.Domain.Repositories;
using API.Infra.Data.Repositories.Base;
using API.Infra.Data.Context;

namespace API.Infra.Data
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        private readonly DomainContext context;
        public ProfileRepository(DomainContext context) : base(context)
        {
            this.context = context;
        }
    }
}