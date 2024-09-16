using System.Threading.Tasks;
using console.interfaces;

namespace PDG.Infraestructure.Data.Services
{
    public class CustomTranslaterService : ITranslater
    {

        public CustomTranslaterService()
        {

        }

        public Task<string> DetectLanguage(string text)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetHelloWorld(string language)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Translate(string text, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}