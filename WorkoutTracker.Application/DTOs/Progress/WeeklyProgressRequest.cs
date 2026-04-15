namespace WorkoutTracker.Application.DTOs.Progress;

public record WeeklyProgressRequest(
    int Year,
    int Month
);