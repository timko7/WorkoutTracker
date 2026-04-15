using System;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Domain.Entities;
using WorkoutTracker.Infrastructure.Data;

namespace WorkoutTracker.Infrastructure.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly AppDbContext _context;

    public WorkoutRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Workout> CreateAsync(Workout workout)
    {
        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();
        return workout;
    }

    public async Task<List<Workout>> GetByMemberAndMonthAsync(Guid memberId, int year, int month)
    {
        return await _context.Workouts
            .Where(w =>
                w.MemberId == memberId &&
                w.Date.Year == year &&
                w.Date.Month == month)
            .ToListAsync();
    }

    public async Task<List<Workout>> GetByMemberIdAsync(Guid memberId)
    {
        return await _context.Workouts
            .Where(w => w.MemberId == memberId)
            .ToListAsync();
    }
}
