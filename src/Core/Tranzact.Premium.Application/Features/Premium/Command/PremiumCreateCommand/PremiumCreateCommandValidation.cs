using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Premium.Application.Features.Premium.Command.PremiumCreateCommand
{
    public class PremiumCreateCommandValidation : AbstractValidator<PremiumCreateCommandRequest>
    {
        public PremiumCreateCommandValidation()
        {
            //could enhance adding other validations for the other fields
            RuleFor(p => p.premiumData.AgeRangeMin)
            .NotEmpty()
            .WithMessage("El campo AgeRangeMin es obligatorio.")
            .GreaterThanOrEqualTo(18)
            .WithMessage("El campo AgeRangeMin debe ser mayor o igual a 18.")
            .LessThanOrEqualTo(150)
            .WithMessage("El campo AgeRangeMin debe ser menor o igual a 150.");

            RuleFor(p => p.premiumData.AgeRangeMax)
            .NotEmpty()
            .WithMessage("El campo AgeRangeMin es obligatorio.")
            .GreaterThanOrEqualTo(18)
            .WithMessage("El campo AgeRangeMin debe ser mayor o igual a 18.")
            .LessThanOrEqualTo(150)
            .WithMessage("El campo AgeRangeMin debe ser menor o igual a 150.");
        }

    }
}
