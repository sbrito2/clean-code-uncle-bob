using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class ActionSpecification : AbstractValidator<Action>
    {
        public ActionSpecification()
        {
            RuleFor(x => x.ActionTypeId)
                .NotNull().NotEmpty().WithMessage("Informe o tipo do leilão.");
        }
    }
}
