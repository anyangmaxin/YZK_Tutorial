using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter_WebAPI.Filter
{
    public class MyExectionFilter : IAsyncExceptionFilter
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public MyExectionFilter(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            string msg;
            //context.Exception
            //throw new NotImplementedException();
            if (this.webHostEnvironment.IsDevelopment())
            {
                msg = context.Exception.ToString();
            }
            else
            {
                msg = "服务端发生未处理异常";
            }
            ObjectResult objectResult = new ObjectResult(new { code = 500, message = msg });
            //异常信息
            context.Result = objectResult;
            //代表异常已经处理
            context.ExceptionHandled = true;
            return Task.CompletedTask;

        }
    }
}
