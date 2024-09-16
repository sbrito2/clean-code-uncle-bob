using API.Domain.CoreLogic.Entities.Base;
using API.Domain.CoreLogic.Specifications;

namespace API.Domain.CoreLogic.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Message { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        public override bool IsValid()
        {
            return IsValid(this, new CustomerSpecification());
        }
    }
}