using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface ICoffeInterface
    {
        Task<Coffe> Create(Coffe coffe);
        Task<List<Coffe>> ReadAll();
        Task<Coffe> Read(long id);
        Task<Coffe> Update(Coffe coffe);
        Task<bool> Delete(long id);
    }
}