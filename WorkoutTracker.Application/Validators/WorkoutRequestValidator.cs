using System;
using System.Data;
using FluentValidation;
using WorkoutTracker.Application.DTOs.Workout;

namespace WorkoutTracker.Application.Validators;

public class WorkoutRequestValidator : AbstractValidator<WorkoutRequest>
{
    public WorkoutRequestValidator()
    {
        RuleFor(x => x.ExerciseType)
            .IsInEnum().WithMessage("Invalid ExerciseType.");

        RuleFor(x => x.DurationInMinutes)
                .GreaterThan(0);

        RuleFor(x => x.CaloriesBurned)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Intensity)
            .InclusiveBetween(1, 10);

        RuleFor(x => x.Fatigue)
            .InclusiveBetween(1, 10);

        RuleFor(x => x.WorkoutDate)
            .NotEmpty().WithMessage("WorkoutDate is required.");
    }

}
