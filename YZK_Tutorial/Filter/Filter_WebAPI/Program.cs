using Filter_WebAPI;
using Filter_WebAPI.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v0", new OpenApiInfo { Title = "Filter学习", Version = "1.0.0.0" });
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Filter学习", Version = "1.0.0.0" });
    //获取 xml文件名
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //获取xml文件路径
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath, true);

});

//
builder.Services.Configure<MvcOptions>(opt =>
{
    //把限流请求Filter注册在第一个，增加效率，无效请求就不占用后续的资源 
    opt.Filters.Add<RateLimitFilter>();
    opt.Filters.Add<MyActionFilter1>();
    opt.Filters.Add<MyExectionFilter>();
    opt.Filters.Add<TranscationScopeFilter>();

});


//注入数据库上下文类
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    //opt.UseSqlServer("Server=127.0.0.1;DataBase=TrainDB2;User ID=sa;Password=123465;Encrypt=True;TrustServerCertificate=True;");
    opt.UseSqlServer(builder.Configuration.GetSection("DB:SqlServer").Value);

    //Server=.;DataBase=TrainDB;User ID=sa;Password=2016;Trusted_Connection=True;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v0/swagger.json", "Filter");
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "自动事务Filter");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
