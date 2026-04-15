using System;
using WorkoutTracker.Domain.Common;
using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public Role Role { get; set; }

    public bool Active { get; set; } = true;

    // 1:1 to Member
    public Member? Member { get; set; }
}
