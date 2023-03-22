using CacheManager.Core;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"configuration.json");
builder.Configuration.AddEnvironmentVariables();

//builder.Services.AddOcelot();

builder.Services.AddOcelot().AddCacheManager(x =>
{
    x.WithRedisConfiguration("redis",
            config =>
            {
                config.WithEndpoint("rediscache", 6379);
            })
    .WithJsonSerializer()
    .WithRedisCacheHandle("redis");
});


var app = builder.Build();


app.UseOcelot();

app.UseAuthorization();


app.Run();
