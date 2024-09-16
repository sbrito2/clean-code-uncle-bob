using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class BidSpecification : AbstractValidator<Bid>
    {
        public BidSpecification()
        {
            RuleFor(x => x.Action)
                .NotNull().NotEmpty().WithMessage("Informe o leilão do lance.");
        }
    }
}
