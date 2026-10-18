using FlowOps.Domain.Enums;

namespace FlowOps.Domain.Entities;

public class Incident
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IncidentPriority Priority { get; set; }
    public IncidentStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime SlaDeadline { get; set; }
}