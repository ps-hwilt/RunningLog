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
    public IEnumerable<ActivityDTO> GetItems()
    {
        var activites = _repository.GetActivities().Select(activity => activity.AsDTO());
        return activites;
    }

    // get api/activity/{id}
    [HttpGet("{id:guid}")]
    public ActionResult<ActivityDTO> GetActivity(Guid id)
    {
        var activity = _repository.GetActivity(id);

        if (activity is null)
        {
            return NotFound();
        }
        return Ok(activity.AsDTO());
    }

    // Post api/activity/{id}
    [HttpPost]
    public ActionResult<ActivityDTO> CreateItem(CreateActivityDTO activityDto)
    {
        Activity activity = new()
        {
            Id = Guid.NewGuid(),
            Distance = activityDto.Distance,
            Time = activityDto.Time,
            StartTime = DateTime.UtcNow
        };
        
        _repository.CreateActivity(activity);

        return CreatedAtAction(nameof(GetActivity), new { id = activity.Id }, activity.AsDTO());
    }
    
    // Put api/activity/{id}
    [HttpPut("{id:guid}")]
    public ActionResult UpdateActivity(Guid id, UpdateActivityDTO activityDto)
    {
        var existingActivity = _repository.GetActivity(id);

        if (existingActivity is null)
        {
            return NotFound();
        }

        var updatedActivity = existingActivity with
        {
            Distance = activityDto.Distance,
            Time = activityDto.Time
        };
        
        _repository.UpdateActivity(updatedActivity);
        
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteActivity(Guid id)
    {
        var existingActivity = _repository.GetActivity(id);

        if (existingActivity is null)
        {
            return NotFound();
        }
        
        _repository.DeleteActivity(id);

        return NoContent();
    }
}