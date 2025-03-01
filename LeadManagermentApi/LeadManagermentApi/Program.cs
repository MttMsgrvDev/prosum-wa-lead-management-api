using FluentValidation;
using LeadManagermentApi.Behavoirs;
using LeadManagermentApi.Data.Context;
using LeadManagermentApi.Data.Models;
using LeadManagermentApi.Exceptions;
using LeadManagermentApi.Repositories;
using LeadManagermentApi.Services.Clock;
using LeadManagermentApi.Services.Filtering;
using LeadManagermentApi.Services.Include;
using LeadManagermentApi.Services.Sort;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

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

builder.Services.AddScoped<IClockService, ClockService>();

builder.Services.AddScoped<IReadRepository<Lead>, BaseReadRepository<Lead>>();
builder.Services.AddScoped<IWriteRepository<Lead>, BaseWriteRepository<Lead>>();
builder.Services.AddScoped<IReadWriteRepository<Lead>, BaseReadWriteRepository<Lead>>();

builder.Services.AddScoped<IReadRepository<Contact>, BaseReadRepository<Contact>>();
builder.Services.AddScoped<IWriteRepository<Contact>, BaseWriteRepository<Contact>>();
builder.Services.AddScoped<IReadWriteRepository<Contact>, BaseReadWriteRepository<Contact>>();

builder.Services.AddScoped(typeof(IFilteringService<>), typeof(FilteringService<>));

builder.Services.AddScoped(typeof(IIncludeService<>), typeof(IncludeService<>));

builder.Services.AddScoped(typeof(ISortingService<>), typeof(SortingService<>));

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
