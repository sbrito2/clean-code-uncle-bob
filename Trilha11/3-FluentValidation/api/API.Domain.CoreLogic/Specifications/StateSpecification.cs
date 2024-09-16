using FluentValidation;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.CoreLogic.Specifications
{
    public class StateSpecification : AbstractValidator<State>
    {
        public StateSpecification()
        {

        }
    }
}
