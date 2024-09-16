using API.Domain.Entities.Base;

namespace API.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}