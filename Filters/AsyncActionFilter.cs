using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace corewebapi.Filters
{
    //Asynchronous Action Filter
    public class AsyncActionFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new System.NotImplementedException();
            // execute any code before the action executes
            // var result = await next();
            // execute any code after the action executes
        }
    }
}