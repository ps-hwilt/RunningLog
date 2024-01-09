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
    
    [HttpGet]
    public IEnumerable<ActivityDTO> GetItems()
    {
        var activites = _repository.GetActivities().Select(activity => activity.AsDTO());
        return activites;
    }

    [HttpGet("{id}")]
    public ActionResult<ActivityDTO> GetActivity(int id)
    {
        var activity = _repository.GetActivity(id);

        if (activity is null)
        {
            return NotFound();
        }
        return Ok(activity.AsDTO());
    }
}