using System;

namespace WorkoutTracker.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    { }
}
