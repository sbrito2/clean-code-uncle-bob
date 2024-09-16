using System.Threading.Tasks;
using console.interfaces;
using Google.Cloud.Translation.V2;

namespace PDG.Infraestructure.Data.Services
{
    public class TranslaterService
    {
        private readonly string LanguageCode;

        public TranslaterService(string language)
        {
            this.LanguageCode = language;
        }

        public async Task<string> GetHelloWorld()
        {
            return "Hello World";
        }

        public async Task<string> Translate(string text)
        {
            TranslationClient client = TranslationClient.Create();
            TranslationResult result = client.TranslateText(text, LanguageCode);

            return $"Result: {result.TranslatedText}; detected language {result.DetectedSourceLanguage}";
        }
    }
}