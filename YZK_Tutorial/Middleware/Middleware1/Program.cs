using Microsoft.AspNetCore.Builder;
using Middleware1;
using System.IO.Pipes;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! ");
//app.MapGet("/test", () => "Hello Test!");

app.Map("/test", async (pipeBuilder) =>
{
    pipeBuilder.Use(async (context, next) =>
    {
        context.Response.ContentType = "text/html";
        //前逻辑  输出 内容
        await context.Response.WriteAsync("1 Start <br/>");
        //请求下一个中间件
        await next();
        //后逻辑  输出 内容
        await context.Response.WriteAsync("1 End <br/>");
    });

    pipeBuilder.Use(async (context, next) =>
    {
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("2 Start <br/>");
        await next();
        await context.Response.WriteAsync("2 End <br/>");
    });
    //注册及使用自定义中间件
    pipeBuilder.UseMiddleware<TestMiddleware>();
    pipeBuilder.Run(async ctx =>
    {
        ctx.Response.ContentType = "text/html";
        await ctx.Response.WriteAsync("Hello this is Middleware <br/>");
    });
});


app.Run();
