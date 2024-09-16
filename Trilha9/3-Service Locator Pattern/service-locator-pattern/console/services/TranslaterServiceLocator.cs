using System;
using System.Collections.Generic;
using console.enums;
using console.interfaces;
using console.service;
using PDG.Infraestructure.Data.Services;

namespace console.Factories
{
    public class TranslaterServiceLocator : IService
    {

        public Dictionary<object, object> servicecontainer = null;  
        public TranslaterServiceLocator()  
        {  
            servicecontainer = new Dictionary<object, object>();  
            servicecontainer.Add(typeof(ITranslater), new GoogleApiService());  
            servicecontainer.Add(typeof(ITranslater), new YandexTranslaterService());  
            servicecontainer.Add(typeof(ITranslater), new DapploService());  
            servicecontainer.Add(typeof(ITranslater), new DapploService()); 
        }
        public ITranslater GetService<ITranslater>()  
        {  
            try  
            {  
                return (ITranslater)servicecontainer[typeof(ITranslater)];  
            }  
            catch (Exception ex)  
            {  
                throw new NotImplementedException("Service not available.");  
            }  
        } 
    }
}
