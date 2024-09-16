using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class ProfileSpecification : AbstractValidator<Profile>
    {
        public ProfileSpecification()
        {
            RuleFor(x => x.Description)
                .NotNull().NotEmpty().WithMessage("Informe a descrição do perfil.");
        }
    }
}
