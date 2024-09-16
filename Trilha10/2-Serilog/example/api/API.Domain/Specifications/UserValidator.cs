using API.Domain.Entities;
using FluentValidation;

namespace API.Domain.Specifications
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Informe o nome do usuário")
                .Length(4, 100).WithMessage("O nome deve ter no mínimo 3 caracteres e no máximo 100.");
            
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Informe o e-mail.")
                .EmailAddress().WithMessage("Informe um e-mail válido.");
        }
    }
}