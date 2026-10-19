using FlowOps.Domain.Enums;
using MediatR;

namespace FlowOps.Application.Incidents.Commands.CreateIncident;

public record CreateIncidentCommand(
    string Title,
    string Description,
    IncidentPriority Priority) : IRequest<Guid>;