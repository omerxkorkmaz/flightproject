using FlightProject.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.Application.FluentValidation
{
    public class TicketValidator : AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(x=> x.PNRNumber).NotNull().NotEmpty().WithMessage("PNR Numarası boş geçilemez..");
            RuleFor(x=> x.Departure).NotNull().NotEmpty().WithMessage("Kalkış Numarası boş geçilemez..");
        }
    }
}
