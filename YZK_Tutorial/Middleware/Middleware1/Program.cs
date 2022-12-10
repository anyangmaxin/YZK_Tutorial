using Microsoft.AspNetCore.Builder;
using System.IO.Pipes;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
//app.MapGet("/test", () => "Hello Test!");

app.Map("/test", async (pipeBuilder) =>
{
    pipeBuilder.Use(async (context, next) =>
    {
        context.Response.ContentType = "text/html";
        //ǰ�߼�  ��� ����
        await context.Response.WriteAsync("1 Start <br/>");
        //������һ���м��
        await next();
        //���߼�  ��� ����
        await context.Response.WriteAsync("1 End <br/>");
    });

    pipeBuilder.Use(async (context, next) =>
    {
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("2 Start <br/>");
        await next();
        await context.Response.WriteAsync("2 End <br/>");
    });

    pipeBuilder.Run(async ctx =>
    {        ctx.Response.ContentType = "text/html";
        await ctx.Response.WriteAsync("Hello this is Middleware <br/>");
    });
});

app.Run();
