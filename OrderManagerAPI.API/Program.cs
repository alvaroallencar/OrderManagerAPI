using FluentValidation.AspNetCore;
using OrderManagerAPI.Application.Commands;
using OrderManagerAPI.Domain.Interfaces;
using Microsoft.OpenApi.Models;
using OrderManagerAPI.Application.Validators;
using OrderManagerAPI.Infrastructure.Data;
using OrderManagerAPI.Infrastructure.Initialization;
using OrderManagerAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<CreateOrderCommandValidator>();
    });

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblyContaining<CreateCustomerCommand>(); });

builder.Services.AddSingleton<DapperDbContext>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    return new DapperDbContext(configuration);
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<DatabaseInitializer>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderManagerAPI", Version = "v1" });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
    await initializer.EnsureStoredProceduresAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderManagerAPI v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();