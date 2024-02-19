using CustomerOrderManagement.WebApi;
using CustomerOrderManagement.Application;
using CustomerOrderManagement.Persistence;
using CustomerOrderManagement.Application.Common.Interfaces;
using CustomerOrderManagement.Persistence.Repositories;
using Serilog;
using CustomerOrderManagement.Application.Features.CustomerManagement.Commands.CreateCustomer;
using FluentValidation;
using CustomerOrderManagement.Application.Features.CustomerManagement.Commands.UpdateCustomer;

Log.Logger = new LoggerConfiguration()
    .WriteTo
    .Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day) // add this
    .CreateLogger();

Log.Information("Starting web application");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(); // <-- Add this line


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
builder.Services.AddTransient<IValidator<UpdateCustomerCommand>, UpdateCustomerCommandValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.UseApiVersioning();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
