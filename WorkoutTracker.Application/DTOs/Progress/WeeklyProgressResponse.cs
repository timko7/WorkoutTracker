namespace WorkoutTracker.Application.DTOs.Progress;

public record WeeklyProgressResponse(
    int WeekNumber,
    int TotalDuration,
    int WorkoutCount,
    double AverageIntensity,
    double AverageFatigue
);