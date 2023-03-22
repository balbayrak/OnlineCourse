
using HealthChecks.UI.Client;
using OnlineCourse.CourseProgram.Application.Configuration;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OnlineCourse.CourseProgram.Persistence.Configuration;
using OnlineCourse.Persistence.Repository.Settings;
using OnlineCourse.WebApi.Configuration;
using Serilog;
using OnlineCourse.WebApi.Logging;
using OnlineCourse.CourseProgram.Caching.Configuration;

var builder = WebApplication.CreateBuilder(args);

//var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

var logger = LoggingConfigurator.ConfigureLogging();
var loggerFactory = new LoggerFactory().AddSerilog(logger);

builder.Host.UseSerilog(logger);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOriginPolicy",
                      builder =>
                      {
                          builder.AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowAnyOrigin();
                      });
});


builder.Services.AddApplicationConfigurations();

builder.Services.AddPersistenceConfigurations(builder.Configuration);


var databaseSettingOption = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();

builder.Services.AddHealthChecks()

    .AddNpgSql(
    npgsqlConnectionString: databaseSettingOption.ConnectionString,
    name: "CourseProgram Db Check",
    failureStatus: HealthStatus.Unhealthy | HealthStatus.Degraded,
    tags: new string[] { "courseprogramdb-postgresql" });


var cacheOption = builder.Configuration.GetSection("CacheOption").Get<CachingOption>();
builder.Services.AddResponseCacheConfigurations(option =>
{
    option.Uri = cacheOption.Uri;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

#region Middlewares

app.UseGeneralExceptionMiddleware();

#endregion

app.UseCors("AllowedOriginPolicy");

#region Db Migrator

await app.RunMigratorAsync();

#endregion


app.MapControllers();


app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
