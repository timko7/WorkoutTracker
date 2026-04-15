using System;
using System.Data;
using FluentValidation;
using WorkoutTracker.Application.DTOs.Progress;

namespace WorkoutTracker.Application.Validators;

public class WeeklyProgressRequestValidator : AbstractValidator<WeeklyProgressRequest>
{
    public WeeklyProgressRequestValidator()
    {
        RuleFor(x => x.Month)
                .InclusiveBetween(1, 12).WithMessage("Month must be between 1 and 12.");

        RuleFor(x => x.Year)
            .InclusiveBetween(2000, DateTime.Now.Year).WithMessage($"Year must be between 2000 and {DateTime.Now.Year}.");
    }
}
