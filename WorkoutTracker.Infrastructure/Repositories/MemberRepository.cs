using System;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Domain.Entities;
using WorkoutTracker.Infrastructure.Data;

namespace WorkoutTracker.Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _context;

    public MemberRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Member> CreateAsync(Member member)
    {
        _context.Members.Add(member);
        await _context.SaveChangesAsync();
        return member;
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Members.AnyAsync(m => m.Email == email);
    }

    public async Task<Member?> GetByIdAsync(Guid id)
    {
        return await _context.Members
            .Include(m => m.Workouts)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    
    public async Task<Member?> GetByUserIdAsync(Guid userId)
    {
        return await _context.Members
            .Include(m => m.Workouts)
            .FirstOrDefaultAsync(m => m.UserId == userId);
    }
}
