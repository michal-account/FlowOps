using FlowOps.Domain.Enums;

namespace FlowOps.Application.Incidents.Queries.GetIncidents;

public record IncidentDto(
    Guid Id,
    string Title,
    string Description,
    IncidentPriority Priority,
    IncidentStatus Status,
    DateTime CreatedAt,
    DateTime SlaDeadline
    );