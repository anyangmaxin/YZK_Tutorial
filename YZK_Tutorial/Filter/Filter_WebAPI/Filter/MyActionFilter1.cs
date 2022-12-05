using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter_WebAPI.Filter
{
    public class MyActionFilter1 : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
