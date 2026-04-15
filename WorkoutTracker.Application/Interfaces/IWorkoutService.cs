using System;
using WorkoutTracker.Application.DTOs.Progress;
using WorkoutTracker.Application.DTOs.Workout;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Interfaces;

public interface IWorkoutService
{
    Task CreateWorkoutAsync(Guid userId, WorkoutRequest request);
    Task<List<Workout>> GetByMemberAndMonthAsync(Guid memberId, WeeklyProgressRequest request);
    Task<List<WorkoutResponse>> GetWorkoutsByUserIdAsync(Guid userId);

    
}
