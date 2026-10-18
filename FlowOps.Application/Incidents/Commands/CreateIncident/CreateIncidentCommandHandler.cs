using FlowOps.Application.Common.Interfaces;
using FlowOps.Domain.Entities;
using FlowOps.Domain.Enums;
using MediatR;

namespace FlowOps.Application.Incidents.Commands.CreateIncident;

public class CreateIncidentCommandHandler : IRequestHandler<CreateIncidentCommand, Guid>
{
    private readonly IFlowOpsDbContext _context;

    public CreateIncidentCommandHandler(IFlowOpsDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
    {
        var incident = new Incident
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Priority = request.Priority,
            Status = IncidentStatus.Open,
            CreatedAt = DateTime.UtcNow,
            SlaDeadline = DateTime.UtcNow.AddHours(24) // Example SLA deadline of 24 hours
        };

        _context.Incidents.Add(incident);

        await _context.SaveChangesAsync(cancellationToken);

        return incident.Id;
    }
}
