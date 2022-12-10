using Filter_WebAPI;
using Filter_WebAPI.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.Configure<MvcOptions>(opt =>
{
    opt.Filters.Add<MyActionFilter1>();
    opt.Filters.Add<MyExectionFilter>();

});


//注入数据库上下文类
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    opt.UseSqlServer("Server=127.0.0.1;DataBase=TrainDB2;User ID=sa;Password=123465;Encrypt=True;TrustServerCertificate=True;");
    
    //Server=.;DataBase=TrainDB;User ID=sa;Password=2016;Trusted_Connection=True;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
