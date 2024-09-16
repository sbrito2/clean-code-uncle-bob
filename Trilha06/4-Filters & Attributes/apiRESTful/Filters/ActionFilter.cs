namespace apiRESTful.Filter
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Passando pelo Action Filter ANTES do metodo");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Passando pelo Action Filter DEPOIS do metodo");
        }
    }
}