using FlowOps.Application.Incidents.Commands.CreateIncident;
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

        return app;
    }

    private static async Task<IResult> CreateIncident(CreateIncidentCommand command, ISender sender)
    {
        var incidentId = await sender.Send(command);
        return Results.Created($"/api/incidents/{incidentId}", new { Id = incidentId });
    }
}