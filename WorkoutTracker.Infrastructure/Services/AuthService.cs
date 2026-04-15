using System;
using WorkoutTracker.Application.Common.Exceptions;
using WorkoutTracker.Application.DTOs.Auth;
using WorkoutTracker.Application.DTOs.Member;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Services;

public class AuthService : IAuthService
{
    // private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    // private readonly IMemberRepository _memberRepository;
    private readonly IMemberService _memberService;
    private readonly IJwtService _jwtService;

    public AuthService(IJwtService jwtService, IUserService userService, IMemberService memberService)
    {
        // _userRepository = userRepository;
        // _memberRepository = memberRepository;
        _jwtService = jwtService;
        _userService = userService;
        _memberService = memberService;
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userService.GetByEmailAsync(request.Email)
            ?? throw new UnauthorizedException("Invalid email or password.");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedException("Invalid email or password.");

        if (!user.Active)
            throw new UnauthorizedException("User account is inactive.");

        var token = _jwtService.GenerateToken(user);
        return new AuthResponse(token, user.Email, user.Role.ToString());
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        if (await _userService.ExistsByEmailAsync(request.Email))
            throw new EmailAlreatyExistsException($"Email already in use: {request.Email}");

        var user = new User
        {
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = request.Role,
            Active = true
        };

        var created = await _userService.CreateAsync(user);
        var member = new MemberRequest
        (
            request.FirstName,
            request.LastName,
            request.Email
        );
        await _memberService.CreateAsync(member);
        var token = _jwtService.GenerateToken(created);

        return new AuthResponse(token, created.Email, created.Role.ToString());
    }
}
