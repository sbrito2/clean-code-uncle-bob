using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class PropertySpecification : AbstractValidator<Property>
    {
        public PropertySpecification()
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty().WithMessage("Informe o título do imóvel.")
                .MinimumLength(10).MaximumLength(50).WithMessage("Campo título aceita entre 10 à 50 caracteres.");
            
            RuleFor(x => x.Description)
                .NotNull().NotEmpty().WithMessage("Informe a descrição do imóvel.");

            RuleFor(x => x.Description)
                .MinimumLength(10).MaximumLength(200).WithMessage("Campo descrição aceita entre 10 à 200 caracteres.");
        }
    }
}
