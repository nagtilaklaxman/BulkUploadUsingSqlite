using API;
using API.Hubs;
using API.Services;
using Application.ESanjeevani.InstituteMember;
using Application.Job;
using Domain.Common.Entities;
using Domain.Common.interfaces;
using Domain.Common.interfaces.FileHelper;
using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Validations;
using FluentValidation;
using Infrastructure.Common;
using Infrastructure.Common.Jobs;
using Infrastructure.ESanjeevani.InstituteMember;
using Infrastructure.ESanjeevani.InstituteMember.FileHelper;
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
builder.Services.AddSignalR();
builder.Services.AddTransient<LogFilePathEnricher>();

builder.Services.AddCommonInfrastructure();
builder.Services.AddESanjeevaniInstituteMemberInfrastructure();

builder.Services.AddESanjeevaniInstituteMemberApplication();
builder.Services.Scan(scan => scan
    // We start out with all types in the assembly of ITransientService
    .FromExecutingAssembly()
    .AddClasses(classes => classes.AssignableTo(typeof(IFileHelper<>)))
    .AsImplementedInterfaces()
    .WithScopedLifetime()
    
);
    /*.AddClasses(classes => classes.AssignableTo(typeof(IMapper<,>)))
    .AsImplementedInterfaces()
    .WithScopedLifetime()*/
builder.Services.AddScoped(typeof(IMapper<InstituteMemberExcelEntity, InstituteMemberBulkEntity>),
    typeof(ExcelEntityToBulkEntity));
builder.Services.AddScoped<IValidator<InstituteMemberBulkEntity>, InstituteMemberBulkEntityValidator>();
builder.Services.AddScoped<INotificationService<JobRecord>, JobNotificationService>();

var app = builder.Build();

//app.UseResponseCompression();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(allowAllOriginsPolicy);
app.UseAuthorization();

app.MapControllers();
app.MapHub<JobHub>("/JobHub");

app.Run();

