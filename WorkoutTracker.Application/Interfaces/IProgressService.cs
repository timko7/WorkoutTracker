using System;
using WorkoutTracker.Application.DTOs.Progress;

namespace WorkoutTracker.Application.Interfaces;

public interface IProgressService
{
    Task<List<WeeklyProgressResponse>> GetMonthlyProgressAsync(Guid userId, WeeklyProgressRequest request);
}
