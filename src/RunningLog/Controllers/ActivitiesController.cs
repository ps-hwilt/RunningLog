using Microsoft.AspNetCore.Mvc;
using RunningLog.DTO;
using RunningLog.Extensions;
using RunningLog.Models;
using RunningLog.Repositories;

namespace RunningLog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly IActivitiesRepository _repository;

    public ActivitiesController(IActivitiesRepository repository)
    {
        _repository = repository;

    }
    
    // Put api/activity/
    [HttpGet]
    public async Task<IEnumerable<ActivityDTO>> GetActivitiesAsync()
    {
        var activites = (await _repository.GetActivitiesAsync())
            .Select(activity => activity.AsDTO());
        return activites;
    }

    // get api/activity/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ActivityDTO>> GetActivityAsync(Guid id)
    {
        var activity = await _repository.GetActivityAsync(id);

        if (activity is null)
        {
            return NotFound();
        }
        return Ok(activity.AsDTO());
    }

    // Post api/activity/{id}
    [HttpPost]
    public async Task<ActionResult<ActivityDTO>> CreateActivityAsync(CreateActivityDTO activityDto)
    {
        Activity activity = new()
        {
            Id = Guid.NewGuid(),
            Distance = activityDto.Distance,
            Time = activityDto.Time,
            StartTime = DateTime.UtcNow
        };
        
        await _repository.CreateActivityAsync(activity);

        return CreatedAtAction(nameof(GetActivityAsync), new { id = activity.Id }, activity.AsDTO());
    }
    
    // Put api/activity/{id}
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateActivityAsync(Guid id, UpdateActivityDTO activityDto)
    {
        var existingActivity = await _repository.GetActivityAsync(id);

        if (existingActivity is null)
        {
            return NotFound();
        }

        var updatedActivity = existingActivity with
        {
            Distance = activityDto.Distance,
            Time = activityDto.Time
        };
        
        await _repository.UpdateActivityAsync(updatedActivity);
        
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteActivityAsync(Guid id)
    {
        var existingActivity = await _repository.GetActivityAsync(id);

        if (existingActivity is null)
        {
            return NotFound();
        }
        
        await _repository.DeleteActivityAsync(id);

        return NoContent();
    }

}