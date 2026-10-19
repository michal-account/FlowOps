using FluentValidation;

namespace FlowOps.Application.Incidents.Commands.CreateIncident;

public class CreateIncidentCommandValidator : AbstractValidator<CreateIncidentCommand>
{
    public CreateIncidentCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Tytuł incydentu jest wymagany")
            .MaximumLength(200).WithMessage("Tytuł nie może przekraczać 200 znaków");

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Opis nie może przekraczać 2000 znaków");

        RuleFor(x => x.Priority)
            .IsInEnum().WithMessage("Podano nieprawidłowy priorytet.");
    }
}