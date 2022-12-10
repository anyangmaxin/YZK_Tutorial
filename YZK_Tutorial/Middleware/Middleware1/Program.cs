using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
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
});

app.Run();
