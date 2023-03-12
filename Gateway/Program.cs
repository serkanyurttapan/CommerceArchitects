using Microsoft.AspNetCore.Mvc;
using Ocelot;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureAppConfiguration((host, config) =>
{
    config.AddJsonFile("ocelot.json", false, true);
}).UseUrls("http://localhost:7000/");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

builder.Services.AddOcelot(builder.Configuration);
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

app.UseOcelot();

app.Run();
