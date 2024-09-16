namespace apiRESTful.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine("Uma exceção não tratada ocorreu na action");
        }
    }
}