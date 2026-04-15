using System;
using WorkoutTracker.Application.Common.Exceptions;
using WorkoutTracker.Application.DTOs.Progress;
using WorkoutTracker.Application.DTOs.Workout;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Services;

public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;
    // private readonly IMemberRepository _memberRepository;
    private readonly IMemberService _memberService;
    private readonly IUserService _userService;
    public WorkoutService(IWorkoutRepository workoutRepository, IMemberService memberService, IUserService userService)
    {
        _workoutRepository = workoutRepository;
        _memberService = memberService;
        _userService = userService;
    }

    public async Task CreateWorkoutAsync(Guid userId, WorkoutRequest request)
    {
        // TODO:
        // 1. Naći MemberId iz UserId
        // 2. Mapirati DTO -> Entity
        // 3. Sačuvati u bazu

        var user = await _userService.GetByIdAsync(userId);
        var member = await _memberService.GetByIdAsync(user!.Member!.Id)
            ?? throw new NotFoundException($"Member with ID {user!.Member!.Id} not found.");
        var workout = new Workout
        {
            ExerciseType = request.ExerciseType,
            DurationInMinutes = request.DurationInMinutes,
            CaloriesBurned = request.CaloriesBurned,
            Intensity = request.Intensity,
            Fatigue = request.Fatigue,
            Notes = request.Notes,
            Date = request.WorkoutDate,
            Member = member
        };

        await _workoutRepository.CreateAsync(workout);
        //TODO: Mapirati Entity -> DTO i vratiti odgovor
    }

    public async Task<List<Workout>> GetByMemberAndMonthAsync(Guid memberId, WeeklyProgressRequest request)
    {
        return await _workoutRepository.GetByMemberAndMonthAsync(memberId, request.Year, request.Month);
    }

    public async Task<List<WorkoutResponse>> GetWorkoutsByUserIdAsync(Guid userId)
    {
        var user = await _userService.GetByIdAsync(userId);
        var member = await _memberService.GetByIdAsync(user!.Member!.Id);

        var workouts = await _workoutRepository.GetByMemberIdAsync(member!.Id);

        return workouts.Select(w => new WorkoutResponse
        (
            w.ExerciseType,
            w.DurationInMinutes,
            w.CaloriesBurned,
            w.Intensity,
            w.Fatigue,
            w.Notes,
            w.Date
        )).ToList();
    }
}
