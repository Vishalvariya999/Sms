using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sms.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is UnauthorizedAccessException exception)
            {
                context.Result = new ObjectResult(exception.Message)
                {
                    StatusCode = 401,
                };
                context.ExceptionHandled = true;
                return;
            }
        }
    }
}
