namespace Middleware1
{
    public class TestMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// 约定需要一个RequestDelegate的参数
        /// </summary>
        /// <param name="next"></param>
        public TestMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("TestMiddleware Start <br/>");
            //执行下一个中间件
            await this.next(context);
            await context.Response.WriteAsync("TestMiddleware End <br/>");

        }
    }
}
