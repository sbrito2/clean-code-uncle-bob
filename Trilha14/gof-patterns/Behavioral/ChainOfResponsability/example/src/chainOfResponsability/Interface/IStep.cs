using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace chainOfResponsability
{
    public interface IStep<Tin, Tout>
    {
        Tout Execute(Tin input, PipelineContext context);
    }
}