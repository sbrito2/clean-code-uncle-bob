
using API.Domain.CoreLogic.Entities.Base;
using API.Domain.CoreLogic.Specifications;

namespace API.Domain.CoreLogic.Entities
{
    public class Resource : Entity
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int ResourceTypeId { get; set; }
        public int PropertyId { get; set; }
        public ResourceType ResourceType { get; set; }
        public Property Property { get; set; }

        public override bool IsValid()
        {
            return IsValid(this, new ResourceSpecification());
        }
    }
}