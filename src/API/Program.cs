using API;
using API.Extensions;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.SQLite($"{Environment.CurrentDirectory}/logs/logs.db")
    .Enrich.FromLogContext()
    .Enrich.With<LogFilePathEnricher>()
    .WriteTo.Map(LogFilePathEnricher.LogFilePathPropertyName,
        (logFilePath, wt) => wt.File($"{logFilePath}"), sinkMapCountLimit: 1)); ;
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<LogFilePathEnricher>();
builder.Services.AddSingleton<ILogFilePathLoder, LogFilePathLoader>();
builder.Services.AddQueueManager();
builder.Services.AddBackgroundServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

