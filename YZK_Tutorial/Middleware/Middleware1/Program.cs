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
    //�����֤����м�������������ʼ
    pipeBuilder.UseMiddleware<CheckMiddleware>();
    pipeBuilder.Use(async (context, next) =>
    {
        //ǰ�߼�  ��� ����
        await context.Response.WriteAsync("1 Start <br/>");
        //������һ���м��
        await next();
        //���߼�  ��� ����
        await context.Response.WriteAsync("1 End <br/>");
    });

    pipeBuilder.Use(async (context, next) =>
    {
      
        await context.Response.WriteAsync("2 Start <br/>");
        await next();
        await context.Response.WriteAsync("2 End <br/>");
    });
    //ע�ἰʹ���Զ����м��
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
