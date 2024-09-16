using PDG.Infraestructure.Data.Services;

namespace console.Factories
{
    public class LanguageFactory
    {
        public TranslaterService GetInstance(string language)
        {
            switch (language)
            {
                case "English":
                    return new TranslaterService("en");
                case "Portuguese":
                    return new TranslaterService("pt");
                case "Italy":
                    return new TranslaterService("it");
                case "Dutch":
                    return new TranslaterService("nl");
                case "Korean":
                    return new TranslaterService("ko");
                case "Spanish":
                    return new TranslaterService("sp");
                case "Afrikaans":
                    return new TranslaterService("af");
                case "Russian":
                    return new TranslaterService("ru");
                case "Romanian":
                    return new TranslaterService("ro");
                case "Vietnamese":
                    return new TranslaterService("vi");
                case "Filipino":
                    return new TranslaterService("tl");
                case "Thai":
                    return new TranslaterService("th");
                case "Arabic":
                    return new TranslaterService("ar");
                case "Japanese":
                    return new TranslaterService("ja");
                default:
                    return new TranslaterService("eo");
            }
        }
    }
}