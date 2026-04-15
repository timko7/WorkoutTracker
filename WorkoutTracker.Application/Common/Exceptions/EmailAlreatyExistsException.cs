using System;

namespace WorkoutTracker.Application.Common.Exceptions;

public class EmailAlreatyExistsException : Exception
{
    public EmailAlreatyExistsException(string message) : base(message)
    { }
}
