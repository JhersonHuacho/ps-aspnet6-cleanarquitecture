using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    private readonly IEventRepository _eventRepository;

    public CreateEventCommandValidator(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Date)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(DateTime.Now);
        
        RuleFor(e => e)
            .MustAsync(EventNameAndDateUnique)
            .WithMessage("An event with the same name and date already exists.");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0);
        


        //RuleFor(p => p.Artist)
        //    .NotEmpty().WithMessage("{PropertyName} is required.")
        //    .NotNull()
        //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        //RuleFor(p => p.Description)
        //    .NotEmpty().WithMessage("{PropertyName} is required.")
        //    .NotNull()
        //    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        //RuleFor(p => p.ImageUrl)
        //    .NotEmpty().WithMessage("{PropertyName} is required.")
        //    .NotNull()
        //    .MaximumLength(2000).WithMessage("{PropertyName} must not exceed 2000 characters.");

        //RuleFor(p => p.CategoryId)
        //    .NotEmpty().WithMessage("{PropertyName} is required.")
        //    .NotNull();
    }

    private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken cancellation)
    {
        return !(await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date));
    }
}
