using Microsoft.AspNetCore.Http.Features;
using RunningLog.Models;

namespace RunningLog.Repositories;

public class InMemActivitiesRepository : IActivitiesRepository
{
    private readonly List<Activity> _activities = new()
    {
        new Activity
        {
            Id = 1,
            Distance = "5",
            Time = "00:40:23",
            StartTime = DateTime.UtcNow
        },
        new Activity
        {
            Id = 2,
            Distance = "3",
            Time = "00:23:00",
            StartTime = DateTime.UtcNow
        },
        new Activity
        {
            Id = 3,
            Distance = "1",
            Time = "00:4:35",
            StartTime = DateTime.UtcNow
        }
    };

    public IEnumerable<Activity> GetActivities()
    {
        return _activities;
    }

    public Activity GetActivity(int Id)
    {
        return _activities.SingleOrDefault(a => a.Id == Id);
    }
}