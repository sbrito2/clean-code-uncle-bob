namespace API.Presentation.API.ViewModels.Customer
{
    public class  CustomerResponseViewModel 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Data { get; set; }
        public string Message { get; set; }
        public int PropertyId { get; set; }
        public GenericComboboxViewModel Property { get; set; }
    }
}