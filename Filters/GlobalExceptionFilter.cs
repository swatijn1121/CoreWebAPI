using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace corewebapi.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError("Error has raised !!");
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            _logger.LogInformation($"My Exception Controller : {controllerName} , Action : {actionName}");
             context.Result = new RedirectToRouteResult(
                new RouteValueDictionary 
                { 
                    { "controller", "Student" }, 
                    { "action", "Get" } 
                });
        }
    }
}