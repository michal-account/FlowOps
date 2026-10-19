using MediatR;

namespace FlowOps.Application.Incidents.Queries.GetIncidents;

public record GetIncidentsQuery() : IRequest<List<IncidentDto>>;
