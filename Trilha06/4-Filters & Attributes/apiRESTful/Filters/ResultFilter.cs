namespace apiRESTful.Filter
{
     public class ResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("Passando pelo result filter antes de retornar ao usuario.");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Passando pelo result filter apos retornar ao usuario, ja nao podemos alterar a resposta.");
        }
    }
}