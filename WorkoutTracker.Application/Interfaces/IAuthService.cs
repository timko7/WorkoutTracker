using System;
using WorkoutTracker.Application.DTOs.Auth;

namespace WorkoutTracker.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
}
