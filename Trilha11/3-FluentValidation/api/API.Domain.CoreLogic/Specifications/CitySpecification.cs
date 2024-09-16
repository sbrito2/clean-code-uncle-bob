using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class CitySpecification : AbstractValidator<City>
    {
        public CitySpecification()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("Informe o nome da cidade.");
        }
    }
}
