using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Implementations
{
    public class CoffeImp : ICoffeInterface
    {
        public async Task<Coffe> Create(Coffe coffe)
        {
            var context = new contextEntities();
            
            if(coffe.CofCountry != null && coffe.CofDescription != null)
                 context.Coffe.Add(coffe);

            await context.SaveChangesAsync();

            return coffe;
        }

        public async Task<Coffe> Read(long id)
        {
            var context = new contextEntities();
            
            var coffe = await context.Coffe.FindAsync(id);

            return coffe;
        }

        public Task<List<Coffe>> ReadAll()
        {
            var context = new contextEntities();
            
            var coffes = context.Coffe.ToList();

            return Task.FromResult(coffes);
        }

        public Task<Coffe> Update(Coffe coffe)
        {
            var context = new contextEntities();

            var response = context.Coffe.Any(x => x.CofId == coffe.CofId);
            if(!response)
            {
                return null;
            }

            if(coffe.CofCountry != null && coffe.CofDescription != null)
                context.Coffe.Update(coffe);

            context.SaveChangesAsync();

            return Task.FromResult(coffe);
        }

        public Task<bool> Delete(long id)
        {
            var context = new contextEntities();

            var coffe = context.Coffe.Find(id);
            if(coffe == null)
            {
                return Task.FromResult(false);
            }
            
            context.Remove(coffe);

            context.SaveChangesAsync();

            return Task.FromResult(true);
        }
    }
}