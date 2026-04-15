using System;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
    string? ExtractEmail(string token);
    bool IsValid(string token, string email);
}
