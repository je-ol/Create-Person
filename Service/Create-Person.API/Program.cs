using MediatR;
using Create_Person.Business.PersonContext.CommandHandlers;
using Create_Person.Business.PersonContext.QueryHandlers;
using Create_Person.Business.Services;
using Create_Person.Core.Services;
using Create_Person.Core.PersonContext.DTOs;
using Create_Person.Core.PersonContext.Queries;
using Create_Person.Core.PersonContext.Validator;
using Create_Person.Domain.Repositories;
using Create_Person.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Serilog;
using Microsoft.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePersonCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetPersonQueryHandler).Assembly));
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IValidator<CreatePersonDto>, CreatePersonDtoValidator>();
builder.Services.AddScoped<IValidator<GetPersonQuery>, GetPersonQueryValidator>();
builder.Logging.AddConsole();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/logfile.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddMemoryCache();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
