using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using console.Domain.Services;
using console.Factories;
using System.Threading.Tasks;
using PDG.Infraestructure.Data.Services;
using Microsoft.Extensions.Configuration;
using System.IO;

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

                
            var factory = new LanguageFactory();
            var translater  = factory.GetInstance("Dutch");
            
            var email = new InternationalEmailService(config, translater);

            await email.Send("Email internacional", "Bom dia! Como vai você?");
        }
    }
}
