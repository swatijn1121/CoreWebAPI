using Microsoft.AspNetCore.Mvc.Filters;

namespace corewebapi.Filters
{
    //Synchronous Action Filter
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //our code before action execute
            throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //our code after action execute
            throw new System.NotImplementedException();
        }
    }
}