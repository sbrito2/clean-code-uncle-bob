using System;
using console.enums;
using console.interfaces;
using console.service;
using PDG.Infraestructure.Data.Services;

namespace console.Factories
{
    public class TranslaterFactory
    {
        public ITranslater GetInstance(string translater)
        {
            switch (translater)
            {
                case "GoogleApi":
                    return new GoogleApiService();
                case "Yandex":
                    return new YandexTranslaterService();
                case "Dapplo":
                    return new DapploService();
                default:
                    return new CustomTranslaterService();
            }
        }
    }
}
