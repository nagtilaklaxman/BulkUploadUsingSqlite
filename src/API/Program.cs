using API;
using API.Extensions;
using DocumentFormat.OpenXml.Bibliography;
using Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.SQLite($"{Environment.CurrentDirectory}/logs/logs.db")
    .Enrich.FromLogContext()
    .Enrich.With<LogFilePathEnricher>()
    .WriteTo.Map(LogFilePathEnricher.LogFilePathPropertyName,
        (logFilePath, wt) => wt.File($"{logFilePath}"), sinkMapCountLimit: 1));
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'

var allowAllOriginsPolicy = "_allowAllOriginsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllOriginsPolicy,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyOrigin();
                          policy.AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<LogFilePathEnricher>();
//builder.Services.AddQueueManager();
builder.Services.AddBackgroundServices();

builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(allowAllOriginsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();

