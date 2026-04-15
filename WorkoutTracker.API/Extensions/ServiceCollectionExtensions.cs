using System;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Infrastructure.Data;
using WorkoutTracker.Infrastructure.Repositories;
using WorkoutTracker.Infrastructure.Services;

namespace WorkoutTracker.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();

        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IWorkoutService, WorkoutService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IProgressService, ProgressService>();

        return services;
    }
}
