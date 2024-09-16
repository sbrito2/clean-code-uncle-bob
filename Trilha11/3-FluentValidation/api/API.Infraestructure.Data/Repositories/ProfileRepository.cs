using API.Domain.CoreLogic.Entities;
using API.Domain.Repositories;
using API.Infraestructure.Data.Repositories.Base;
using API.Infraestructure.Data.Context;

namespace API.Infraestructure.Data
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