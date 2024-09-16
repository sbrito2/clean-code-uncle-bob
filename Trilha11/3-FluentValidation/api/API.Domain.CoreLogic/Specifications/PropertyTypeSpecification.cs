using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class PropertyTypeSpecification : AbstractValidator<PropertyType>
    {
        public PropertyTypeSpecification()
        {
            RuleFor(x => x.Description)
                .NotNull().NotEmpty().WithMessage("Informe a descrição do tipo de propriedade.");

        }
    }
}
