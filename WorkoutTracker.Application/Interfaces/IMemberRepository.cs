using System;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Interfaces;

public interface IMemberRepository
{
    Task<Member?> GetByIdAsync(Guid id);

    Task<Member?> GetByUserIdAsync(Guid userId);

    Task<Member> CreateAsync(Member member);

    Task<bool> ExistsByEmailAsync(string email);
}
