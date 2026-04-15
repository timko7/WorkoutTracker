using System;
using WorkoutTracker.Domain.Common;

namespace WorkoutTracker.Domain.Entities;

public class Member : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();

}
