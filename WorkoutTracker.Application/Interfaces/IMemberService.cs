using System;
using WorkoutTracker.Application.DTOs.Member;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Interfaces;

public interface IMemberService
{
  Task<Member> GetByIdAsync(Guid id);
  Task<Member> CreateAsync(MemberRequest request);
}
