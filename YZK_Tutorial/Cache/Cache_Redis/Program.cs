using Cache_Redis.Service;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<BookService>();

//×¢²áRedis
builder.Services.AddStackExchangeRedisCache(options =>
{
    //options.Configuration = "localhost";
    options.Configuration = builder.Configuration.GetValue<string>("DB:Redis:Configuration");
    //options.InstanceName = "mx_";
    options.InstanceName = builder.Configuration.GetValue<string>("DB:Redis:InstanceName");
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
