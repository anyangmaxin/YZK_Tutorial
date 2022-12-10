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
        //ǰ�߼�  ��� ����
        await context.Response.WriteAsync("1 Start <br/>");
        //������һ���м��
        await next();

        //���߼�  ��� ����
        await context.Response.WriteAsync("1 End <br/>");

    });
});

app.Run();
