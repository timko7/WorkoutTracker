namespace WorkoutTracker.Application.DTOs.Auth;

public record AuthResponse(
    string Token,
    string Email,
    string Role
);