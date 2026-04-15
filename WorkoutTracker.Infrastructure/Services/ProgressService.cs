using System;
using WorkoutTracker.Application.DTOs.Progress;
using WorkoutTracker.Application.Interfaces;

namespace WorkoutTracker.Infrastructure.Services;

public class ProgressService : IProgressService
{
    private readonly IMemberService _memberService;
    private readonly IWorkoutService _workoutService;
    private readonly IUserService _userService;

    public ProgressService(IMemberService memberService, IWorkoutService workoutService, IUserService userService)
    {
        _memberService = memberService;
        _workoutService = workoutService;
        _userService = userService;
    }

    public async Task<List<WeeklyProgressResponse>> GetMonthlyProgressAsync(Guid userId, WeeklyProgressRequest request)
    {
        var user = await _userService.GetByIdAsync(userId);
        var member = await _memberService.GetByIdAsync(user!.Member!.Id);

        var workouts = await _workoutService.GetByMemberAndMonthAsync(member!.Id, request);

        var result = workouts
            .GroupBy(w => GetWeekOfMonth(w.Date))
            .Select(g => new WeeklyProgressResponse
            (
                g.Key,
                g.Sum(w => w.DurationInMinutes),
                g.Count(),
                g.Average(w => w.Intensity),
                g.Average(w => w.Fatigue)
            ))
            .OrderBy(r => r.WeekNumber)
            .ToList();

        return result;
    }

    // which week of the month a date falls into (1-5)
    private int GetWeekOfMonth(DateTime date)
    {
        var firstDay = new DateTime(date.Year, date.Month, 1);

        return ((date.Day + (int)firstDay.DayOfWeek - 1) / 7) + 1;
    }
}
