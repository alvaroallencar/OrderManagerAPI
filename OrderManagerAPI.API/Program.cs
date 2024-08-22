using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MediatR;
using FluentValidation.AspNetCore;
using OrderManagerAPI.Application.Commands;
using OrderManagerAPI.Application.Queries;
using OrderManagerAPI.Infrastructure;
using OrderManagerAPI.Domain.Interfaces;
using Microsoft.OpenApi.Models;
using OrderManagerAPI.Application.Validators;
using OrderManagerAPI.Infrastructure.Data;
using OrderManagerAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>());

// Adiciona e configura MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<CreateCustomerCommand>();
});

// Configura o Dapper DbContext
builder.Services.AddSingleton<DapperDbContext>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    return new DapperDbContext(configuration);
});

// Configura os repositórios
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Adiciona e configura o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderManagerAPI", Version = "v1" });
});

var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderManagerAPI v1");
        c.RoutePrefix = string.Empty; // Swagger UI at root
    });
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();