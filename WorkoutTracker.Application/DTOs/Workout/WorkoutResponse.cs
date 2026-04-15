


using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Application.DTOs.Workout;

public record WorkoutResponse(
    ExerciseType ExerciseType,
    int DurationInMinutes,
    int CaloriesBurned,
    int Intensity,
    int Fatigue,
    string? Notes,
    DateTime WorkoutDate
);