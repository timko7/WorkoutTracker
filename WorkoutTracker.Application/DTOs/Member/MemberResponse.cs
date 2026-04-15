using System;

namespace WorkoutTracker.Application.DTOs.Member;

public record MemberResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime CreatedAt
);