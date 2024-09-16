
using System.Threading.Tasks;
using console.interfaces;

namespace PDG.Infraestructure.Data.Services
{
    public class DapploService : ITranslater
    {
        private string languageDefault;

        public DapploService()
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

        public string SetDefaultLanguage(string language)
        {
            switch (language)
            {
                case "English":
                    return "en";
                case "Portuguese":
                    return "pt";
                case "Korean":
                    return "ko";
                case "Spanish":
                    return "sp";
                case "Arabic":
                    return "ar";
                case "Japanese":
                    return "ja";
                default:
                    return "eo";
            }
        }

        public Task<string> Translate(string text)
        {
            return this.Translate(text, this.SetDefaultLanguage(this.languageDefault));
        }
    }
}