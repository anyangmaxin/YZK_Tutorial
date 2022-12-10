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
    opt.SwaggerDoc("v0", new OpenApiInfo { Title = "Filterѧϰ", Version = "1.0.0.0" });
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Filterѧϰ", Version = "1.0.0.0" });
    //��ȡ xml�ļ���
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //��ȡxml�ļ�·��
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath, true);

});

//
builder.Services.Configure<MvcOptions>(opt =>
{
    //����������Filterע���ڵ�һ��������Ч�ʣ���Ч����Ͳ�ռ�ú�������Դ 
    opt.Filters.Add<RateLimitFilter>();
    opt.Filters.Add<MyActionFilter1>();
    opt.Filters.Add<MyExectionFilter>();
    opt.Filters.Add<TranscationScopeFilter>();

});


//ע�����ݿ���������
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
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "�Զ�����Filter");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
