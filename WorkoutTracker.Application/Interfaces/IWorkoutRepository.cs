using System;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Interfaces;

public interface IWorkoutRepository
{
    Task<Workout> CreateAsync(Workout workout);
    Task<List<Workout>> GetByMemberAndMonthAsync(Guid memberId, int year, int month);

    Task<List<Workout>> GetByMemberIdAsync(Guid memberId);
}
