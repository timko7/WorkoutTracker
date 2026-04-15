using System;
using WorkoutTracker.Domain.Common;
using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Domain.Entities;

public class Workout : BaseEntity
{
    public Guid MemberId { get; set; }

    public Member? Member { get; set; }

    public ExerciseType ExerciseType { get; set; }

    public int DurationInMinutes { get; set; }

    public int CaloriesBurned { get; set; }

    public int Intensity { get; set; }

    public int Fatigue { get; set; }

    public string? Notes { get; set; }

    public DateTime Date { get; set; }

}
