using App_Corretora.Data;
using App_Corretora.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using StackExchange.Redis;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<SessaoDB>();
builder.Services.AddTransient<ICorretoraRepository, CorretoraRepository>();
builder.Services.AddCors();

ConfigurationOptions options = new ConfigurationOptions
{
    EndPoints = { "" },
    ConnectTimeout = 10000, 
    SyncTimeout = 10000,
    AbortOnConnectFail = false
};
ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(options);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = ""; 
  
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.WithOrigins("", "", "");
    options.AllowAnyMethod();
    options.AllowAnyHeader();

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }




