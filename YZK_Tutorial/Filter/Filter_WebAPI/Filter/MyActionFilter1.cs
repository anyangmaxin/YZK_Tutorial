using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter_WebAPI.Filter
{
    public class MyActionFilter1 : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //throw new NotImplementedException();
            Console.WriteLine("MyActionFilter1开始执行：");
            //此行代码为分割线，之前为前代码逻辑
            ActionExecutedContext r = await next();

            //后代码逻辑

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
