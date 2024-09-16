using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class CustomerSpecification : AbstractValidator<Customer>
    {
        public CustomerSpecification()
        {
            RuleFor(x => x.Name).
                NotNull().NotEmpty().WithMessage("Informe seu nome.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Preencha o campo email corretamente.")
                .NotNull().NotEmpty().When(m => m.Telephone == null).WithMessage("Informe seu email.");   
        }
    }
}
