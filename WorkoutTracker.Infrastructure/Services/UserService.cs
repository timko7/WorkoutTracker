using System;
using WorkoutTracker.Application.Common.Exceptions;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateAsync(User user)
    {
        if (await ExistsByEmailAsync(user.Email))
            throw new EmailAlreatyExistsException($"Email already in use: {user.Email}");

        return await _userRepository.CreateAsync(user);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _userRepository.ExistsByEmailAsync(email);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email)
            ?? throw new NotFoundException($"User with email {email} not found.");
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id)
            ?? throw new NotFoundException($"User with ID {id} not found.");
    }

    
}
