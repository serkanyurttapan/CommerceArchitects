using BasketAPI.Services;
using BasketAPI.Settings;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();
builder.Services.Configure<RedisConnectSettings>(builder.Configuration.GetSection("RedisSettings"));
builder.Services.AddSingleton(rd =>
{
    var redisSettings = rd.GetRequiredService<IOptions<RedisConnectSettings>>().Value;
    var redis = new RedisService(redisSettings.Host, redisSettings.Port);
    redis.Connect();
    return redis;

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
