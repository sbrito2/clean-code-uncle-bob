using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using console.interfaces;
using Yandex.Translator;
using YandexTranslateCSharpSdk;

namespace PDG.Infraestructure.Data.Services
{
    public class YandexTranslaterService : ITranslater
    {
        public YandexTranslaterService()
        {

        }
        public async Task<string> GetHelloWorld(string language)
        {
            return await this.Translate("Hello World", language);
        }

        public async Task<string> DetectLanguage(string text)
        {
            var wrapper = new YandexTranslateSdk();

            var result = wrapper.DetectLanguageAsync(text);

            return await result;
        }

        public async Task<string> Translate(string text, string language)
        {
            var wrapper = new YandexTranslateSdk();
            wrapper.ApiKey = "theKeyYouGotFromYandexHere";
            string translatedText = await wrapper.TranslateTextAsync(text, "en-fr");

            return translatedText;
        }

        public Task<string> Translate(string text)
        {
            throw new System.NotImplementedException();
        }

        public string SetDefaultLanguage(string language)
        {
            throw new System.NotImplementedException();
        }
    }
}