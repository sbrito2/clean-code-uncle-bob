using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class ResourceTypeSpecification : AbstractValidator<ResourceType>
    {
        public ResourceTypeSpecification()
        {
            RuleFor(x => x.Description)
                .NotNull().NotEmpty().WithMessage("Informe o campo descriçao.");
        }
    }
}
