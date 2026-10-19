using FlowOps.Application.Incidents.Commands.CreateIncident;
using FlowOps.Application.Incidents.Queries.GetIncidents;
using MediatR;

namespace FlowOps.Api.Endpoints;

public static class IncidentEndpoints
{
    public static IEndpointRouteBuilder MapIncidentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/incidents")
            .WithTags("Incidents");

        group.MapPost("/", CreateIncident)
            .WithName("CreateIncident")
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        group.MapGet("/", GetIncidents)
            .WithName("GetIncidents")
            .Produces<List<IncidentDto>>(StatusCodes.Status200OK);

        return app;
    }

    private static async Task<IResult> CreateIncident(CreateIncidentCommand command, ISender sender)
    {
        var incidentId = await sender.Send(command);
        return Results.Created($"/api/incidents/{incidentId}", new { Id = incidentId });
    }

    private static async Task<IResult> GetIncidents(ISender sender)
    {
        var query = new GetIncidentsQuery();
        var result = await sender.Send(query);
        return Results.Ok(result);
    }
}