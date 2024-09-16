using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using console.interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;

namespace console.service
{
    public class GoogleApiService : ITranslater
    {
        private string languageDefault;
        private object StorageClient;

        public GoogleApiService()
        {

        }

        // private object AuthImplicit(string projectId)
        // {
        //     // If you don't specify credentials when constructing the client, the
        //     // client library will look for credentials in the environment.
        //     var credential = GoogleCredential.GetApplicationDefault();
        //     var storage = StorageClient.Create(credential);
            
        //     // Make an authenticated API request.
        //     var buckets = storage.ListBuckets(projectId);
        //     foreach (var bucket in buckets)
        //     {
        //         Console.WriteLine(bucket.Name);
        //     }
        //     return null;
        // }

        public async Task<string> Translate(string message, string language)
        {
            TranslationClient client = TranslationClient.Create();
            TranslationResult result = client.TranslateText(message, LanguageCodes.Russian, LanguageCodes.Portuguese);

            // return $"Result: {result.TranslatedText}; detected language {result.DetectedSourceLanguage}";
            return result.TranslatedText;
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

       // https://dl.google.com/dl/cloudsdk/channels/rapid/GoogleCloudSDKInstaller.exe
       // gcloud auth application-default login
    }
}