using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Application.DTOs.Workout;
using WorkoutTracker.Application.Interfaces;

namespace WorkoutTracker.API.Controllers
{
    [Route("api/workouts")]
    [ApiController]
    [Authorize]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutRequest request)
        {
            Console.WriteLine($"PRINTTTT {User.FindFirstValue(ClaimTypes.NameIdentifier)!}"); // Debug print to check if user ID is being retrieved correctly

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            Console.WriteLine($"User ID from token: {userId}"); // Debug print

            await _workoutService.CreateWorkoutAsync(userId, request);

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForMember()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var workouts = await _workoutService.GetWorkoutsByUserIdAsync(userId);
            return Ok(workouts);
        }
    }
}
