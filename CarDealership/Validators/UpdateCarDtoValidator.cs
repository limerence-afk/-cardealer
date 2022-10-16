using CarDealership.Models;
using FluentValidation;

namespace CarDealership.Validators;

public class UpdateCarDtoValidator : AbstractValidator<UpdateCarDto>
{
    public UpdateCarDtoValidator()
    {
        RuleFor(x => x.IsSold).NotEqual(false);
    }
}