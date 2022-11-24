using DI_Lib1;
using DI_Lib2;
using DI_WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//注入计算类
builder.Services.AddScoped<Calculator>();
//注入TestService
builder.Services.AddScoped<TestService>();


#region 测试多服务注册
builder.Services.AddScoped<Class1>();
builder.Services.AddScoped<Class2>();
builder.Services.AddScoped<Class3>();
builder.Services.AddScoped<Class4>();
#endregion

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
