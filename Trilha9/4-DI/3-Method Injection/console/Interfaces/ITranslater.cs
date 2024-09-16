using System.Threading.Tasks;

namespace console.interfaces
{
    public interface ITranslater
    {
        Task<string>  GetHelloWorld(string language);
        Task<string>  Translate(string text);
        Task<string>  Translate(string text, string language);
        Task<string>  DetectLanguage(string text);
    }
}