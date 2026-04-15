namespace WorkoutTracker.Application.DTOs.Member;

public record MemberRequest(
    string FirstName,
    string LastName,
    string Email
);