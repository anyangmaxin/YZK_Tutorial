using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter_WebAPI.Filter
{
    public class MyActionFilter1 : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //throw new NotImplementedException();
            Console.WriteLine("MyActionFilter1开始执行：");
            ActionExecutedContext r = await next();
            if (r.Exception != null)
            {
                Console.WriteLine("MyActionFilter1执行失败：");
            }
            else
            {
                Console.WriteLine("MyActionFilter1执行成功：");
            }
        }
    }
}
