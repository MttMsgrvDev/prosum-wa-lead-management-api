using FluentValidation;
using LeadManagermentApi.Behavoirs;
using LeadManagermentApi.Data.Context;
using LeadManagermentApi.Data.Models;
using LeadManagermentApi.Exceptions;
using LeadManagermentApi.Features.Leads.Profiles;
using LeadManagermentApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

//builder.Services.AddAutoMapper(new[] { typeof(Program).Assembly });
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.AddOpenBehavior(typeof(ValidationBehavoir<,>));
});

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddDbContextFactory<LeadContext>(options =>
{
    options.UseInMemoryDatabase("LeadManagementDb");
});

builder.Services.AddTransient<IReadRepository<Lead>, BaseReadRepository<Lead>>();
builder.Services.AddTransient<IWriteRepository<Lead>, BaseWriteRepository<Lead>>();
builder.Services.AddTransient<IReadWriteRepository<Lead>, BaseReadWriteRepository<Lead>>();

builder.Services.AddTransient<IReadRepository<Contact>, BaseReadRepository<Contact>>();
builder.Services.AddTransient<IWriteRepository<Contact>, BaseWriteRepository<Contact>>();
builder.Services.AddTransient<IReadWriteRepository<Contact>, BaseReadWriteRepository<Contact>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
