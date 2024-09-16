using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class ActionTypeSpecification : AbstractValidator<ActionType>
    {
        public ActionTypeSpecification()
        {
            RuleFor(x => x.Type)
                .NotNull().NotEmpty().WithMessage("Informe o campo tipo de leilão.")
                .MinimumLength(3).MaximumLength(30).WithMessage("Campo tipo de leilão aceita entre 10 à 50 caracteres.");

            RuleFor(x => x.Description)
                .NotNull().NotEmpty().WithMessage("Informe a descrição do tipo de leilão.")
                .MinimumLength(20).MaximumLength(200);
        }
    }
}
