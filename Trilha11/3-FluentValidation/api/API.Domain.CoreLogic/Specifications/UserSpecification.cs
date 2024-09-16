using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class UserSpecification : AbstractValidator<User>
    {
        public UserSpecification()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("Informe o nome do usuário.")
                .MinimumLength(10).MaximumLength(50).WithMessage("Campo nome aceita entre 10 à 50 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Preencha o campo email corretamente.")
                .NotNull().NotEmpty().WithMessage("Informe o e-mail do usuário.");

            RuleFor(x => x.Cpf)
                .NotNull().NotEmpty().When(m => m.ProfileId == 1).WithMessage("Para usuário administrador precisar informar o cpf.")
                .Length(11).When(x => !x.Equals(null)).WithMessage("Campo cpf aceita 11 caracteres.");
            
            RuleFor(x => x.ProfileId)
                .GreaterThan(0).WithMessage("Informe o perfil do usuário.");
        }
    }
}
