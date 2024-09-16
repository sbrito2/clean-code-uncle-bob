using System.Threading.Tasks;

namespace console.interfaces
{
    public interface IService
    {
        ITranslater GetService<ITranslater>();  
    }
}