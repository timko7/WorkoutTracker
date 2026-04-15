using System;
using WorkoutTracker.Application.Common.Exceptions;
using WorkoutTracker.Application.DTOs.Member;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;
    // private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;

    public MemberService(IMemberRepository memberRepository, IUserService userService)
    {
        _memberRepository = memberRepository;
        _userService = userService;
    }

    public async Task<Member> CreateAsync(MemberRequest request)
    {
        var user = await _userService.GetByEmailAsync(request.Email);
        if (user == null)
        {
            throw new NotFoundException($"User with email {request.Email} not found.");
        }

        if (await _memberRepository.ExistsByEmailAsync(request.Email))
        {
            throw new EmailAlreatyExistsException($"Email already in use: {request.Email}");
        }

        var member = new Member
        {
            UserId = user.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        var created = await _memberRepository.CreateAsync(member);

        return created;
    }

    public async Task<Member> GetByIdAsync(Guid id)
    {
        var member = await _memberRepository.GetByIdAsync(id)
            ?? throw new NotFoundException($"Member with user ID {id} not found.");

        return member;
    }

    // private static MemberResponse MapToResponse(Member member) => new(
    //     member.Id,
    //     member.FirstName,
    //     member.LastName,
    //     member.Email,
    //     member.CreatedAt
    // );
}
