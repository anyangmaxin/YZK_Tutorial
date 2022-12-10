using Dynamic.Json;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace Middleware1
{
    public class CheckMiddleware
    {
        private readonly RequestDelegate next;

        public CheckMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string pwd = context.Request.Query["password"];
            if (pwd == "123")
            {
                //判断 是否是json请求
                if (context.Request.HasJsonContentType())
                {
                    //读取请求体
                    var stream = context.Request.BodyReader.AsStream();
                    //可以使用第三方库 Dynamic.Json  直接转换为dynamic类型
                    dynamic? result = await DJson.ParseAsync(stream);
                    //目前System.Text.Json (.net 6) 不支持把Json反序列化为dynamic类型
                    //dynamic? result =JsonSerializer.Deserialize(stream, typeof(object));

                    context.Items["BodyJson"] = result;

                }
                //执行下一个中间件
                await this.next(context);
            }
            else
            {
                context.Response.StatusCode = 401;
            }
        }
    }
}
