using FlowOps.Domain.Enums;
using MediatR;
using System.Runtime.CompilerServices;

namespace FlowOps.Application.Incidents.Commands.CreateIncident;

public record CreateIncidentCommand(
    string Title,
    string Description,
    IncidentPriority Priority) : IRequest<Guid>;