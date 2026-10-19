using FlowOps.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowOps.Application.Incidents.Queries.GetIncidents;

public class GetIncidentsQueryHandler : IRequestHandler<GetIncidentsQuery, List<IncidentDto>>
{
    private readonly IFlowOpsDbContext _context;

    public GetIncidentsQueryHandler(IFlowOpsDbContext context)
    {
        _context = context;
    }

    public async Task<List<IncidentDto>> Handle(GetIncidentsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Incidents
            .AsNoTracking()
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new IncidentDto(
                x.Id,
                x.Title,
                x.Description,
                x.Priority,
                x.Status,
                x.CreatedAt,
                x.SlaDeadline
                ))
            .ToListAsync(cancellationToken);
    }

}