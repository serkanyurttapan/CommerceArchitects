using Diamond.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrderApplication.Commands;
using OrderApplication.Handlers;
using OrderInfrastructure;
using Shared.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://localhost:7001/");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{ return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value; });

builder.Services.AddScoped<IOrderDbContext, OrderDbContext>();

builder.Services.RegisterRequestHandlers();
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
