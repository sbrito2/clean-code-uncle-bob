using System.Runtime.InteropServices;
using System.Threading.Tasks;
using console.interfaces;
using Google.Cloud.Translation.V2;

namespace console.service
{
    public class GoogleApiService : ITranslater
    {
        private string languageDefault;

        public GoogleApiService()
        {

        }

        public async Task<string> Translate(string message, string language)
        {
            TranslationClient client = TranslationClient.Create();
            TranslationResult result = client.TranslateText("It is raining.", LanguageCodes.Portuguese);

            return $"Result: {result.TranslatedText}; detected language {result.DetectedSourceLanguage}";
        }

        public async Task<string> GetHelloWorld(string language)
        {
            return await this.Translate("Hello World", language);
        }

        public async Task<string> DetectLanguage(string text)
        {
            TranslationClient client = TranslationClient.Create();
            var result = client.DetectLanguage(text);

            return result.Language;
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