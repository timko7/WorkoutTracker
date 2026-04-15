using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Application.DTOs.Auth;

public record RegisterRequest(
    string Email,
    string Password,
    Role Role,
    string FirstName,
    string LastName
);