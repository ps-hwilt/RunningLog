using Microsoft.AspNetCore.Mvc;
using RunningLog.Models;
using RunningLog.Repositories;

namespace RunningLog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly InMemActivitiesRepository _repository;

    public ActivitiesController()
    {
        _repository = new InMemActivitiesRepository();
        
    }
    
    [HttpGet]
    public IEnumerable<Activity> GetItems()
    {
        var activites = _repository.GetActivities();
        return activites;
    }
}