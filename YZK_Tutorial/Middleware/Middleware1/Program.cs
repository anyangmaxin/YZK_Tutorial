using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Middleware1;
using System.IO.Pipes;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! ");
//app.MapGet("/test", () => "Hello Test!");

app.Map("/test", async (pipeBuilder) =>
{
    //检查验证类的中间件，尽量放在最开始
    pipeBuilder.UseMiddleware<CheckMiddleware>();
    pipeBuilder.Use(async (context, next) =>
    {
        //前逻辑  输出 内容
        await context.Response.WriteAsync("1 Start <br/>");
        //请求下一个中间件
        await next();
        //后逻辑  输出 内容
        await context.Response.WriteAsync("1 End <br/>");
    });

    pipeBuilder.Use(async (context, next) =>
    {
      
        await context.Response.WriteAsync("2 Start <br/>");
        await next();
        await context.Response.WriteAsync("2 End <br/>");
    });
    //注册及使用自定义中间件
    //pipeBuilder.UseMiddleware<TestMiddleware>();

    pipeBuilder.Run(async ctx =>
    {      
        await ctx.Response.WriteAsync("Hello this is Middleware <br/>");
        dynamic? obj = ctx.Items["BodyJson"];
        if (obj != null)
        {
            Console.WriteLine(obj.ToString());
            await ctx.Response.WriteAsync($"{obj}<br/>");
        }
    });
});


app.Run();
