using FlightProject.Application.DTOs;
using FlightProject.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.Application.FluentValidation
{
    public class FlightValidator : AbstractValidator<FlightCancelRequest>
    {
        public FlightValidator()
        {
            RuleFor(x => x.PnrNumber).NotNull().NotEmpty().WithMessage("PNR alanı boş geçilemez");
            RuleFor(x => x.TicketNumber).NotNull().NotEmpty().WithMessage("Ticket alanı boş geçilemez");
        }

    }
}
