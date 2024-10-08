using System;
using Microsoft.Extensions.DependencyInjection;
using chainOfResponsability;
using Xunit;

namespace PipelineBuilderTests
{

    public class ToStringStep : IStep<int, string>
    {
        public string Execute(int input, PipelineContext context)
        {
            return input.ToString();
        }
    }

    public class DoublerStep : IStep<string, string>
    {
        public string Execute(string input, PipelineContext context)
        {
            return input + input;
        }
    }

    public class ToIntStep : IStep<string, int>
    {
        public int Execute(string input, PipelineContext context)
        {
            return int.Parse(input);
        }
    }

    public class CancellingStep : IStep<string, string>
    {
        public string Execute(string input, PipelineContext context)
        {
            context.Cancel();
            return "a value";
        }
    }

    public class PipelineBuilderTests
    {
        [Fact(DisplayName = "Simple usage")]
        public void Simple()
        {
            var pipeline = new PipelineBuilder()
                .AddStep(new ToStringStep())
                .AddStep(new DoublerStep())
                .AddStep(new DoublerStep())
                .Build();

            var result = pipeline.Execute(12);
            Assert.Equal("12121212", result.Value);
        }

        [Fact(DisplayName = "Cancel usage")]
        public void Cancel()
        {
            var pipeline = new PipelineBuilder()
                .AddStep(new ToStringStep())
                .AddStep(new CancellingStep())
                .AddStep(new ToIntStep())
                .Build();

            var result = pipeline.Execute(12);
            Assert.Equal(default(int), result.Value);
        }
    }
}