using FlowOps.Api.Endpoints;
using FlowOps.Api.Infrastructure.ExceptionHandling;
using FlowOps.Application.Common.Behaviors;
using FlowOps.Application.Common.Interfaces;
using FlowOps.Application.Incidents.Commands.CreateIncident;
using FlowOps.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<FlowOpsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFlowOpsDbContext>(provider =>
    provider.GetRequiredService<FlowOpsDbContext>());

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateIncidentCommand).Assembly);

    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(CreateIncidentCommand).Assembly);
    
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR()
    .AddStackExchangeRedis(builder.Configuration.GetConnectionString("Redis")!);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapIncidentEndpoints();

app.Run();