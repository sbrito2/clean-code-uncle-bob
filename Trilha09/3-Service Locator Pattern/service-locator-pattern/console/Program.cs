using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using console.Domain.Services;
using console.Factories;
using System.Threading.Tasks;
using PDG.Infraestructure.Data.Services;
using System.IO;
using Microsoft.Extensions.Configuration;
using console.interfaces;
using console.service;

namespace console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
                
            var serviceLocator = new TranslaterServiceLocator();
            ITranslater googleTranslater = serviceLocator.GetService<GoogleApiService>();
            googleTranslater.SetDefaultLanguage("Spanish"); 
            
            var email = new InternationalEmailService(config, googleTranslater);

            await email.Send("Email internacional", "Bom dia! Como vai você?");
        }
    }
}
