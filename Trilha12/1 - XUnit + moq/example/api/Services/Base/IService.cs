using System.Collections.Generic;

namespace API.Services.Base
{
    public interface IService<Entity>
    {
        void Add(Entity entity);
        bool Any(int id);
        List<Entity> GetAll();
        Entity Find(int id);
        Entity Find(params object[] keys);
        void Update(Entity entity);
        void Delete(Entity entity);
        void Delete(params object[] keys);
        void Delete(int id);
    }
}