using API.Domain.Entities.Base;

namespace API.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Message { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}