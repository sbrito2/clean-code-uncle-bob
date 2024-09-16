using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class ResourceSpecification : AbstractValidator<Resource>
    {
        public ResourceSpecification()
        {
            RuleFor(x => x.Description)
                .NotNull().NotEmpty().WithMessage("Informe o campo descriçao.");

            RuleFor(x => x.ResourceTypeId)
                .GreaterThan(0).WithMessage("Informe o tipo do recurso.");
        }
    }
}
