using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using console.Domain.Services;
using console.Factories;
using System.Threading.Tasks;
using PDG.Infraestructure.Data.Services;
using console.interfaces;
using console.service;
using Microsoft.Extensions.Configuration;
using System.IO;
using console.models;

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

            var email = new InternationalEmailService(config);
            email.SetTranslater(new GoogleApiService());

            await email.Send("Email internacional", "Bom dia! Como vai você?", "Spanish");
        }
    }
}
