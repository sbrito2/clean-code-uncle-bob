namespace apiRESTful.Filter
{
     public class ResourceFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("Passando pelo Resource Filter ANTES do metodo");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("Passando pelo Resource Filter DEPOIS do metodo");
        }
    }
}