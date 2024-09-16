using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace chainOfResponsability
{
    public class PipelineConfiguration
    {
        public static IServiceProvider ServiceProvider { get; set; }
    }
}