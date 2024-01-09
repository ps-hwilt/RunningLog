using Microsoft.AspNetCore.Http.Features;
using RunningLog.Models;

namespace RunningLog.Repositories;

public class InMemActivitiesRepository : IActivitiesRepository
{
    private readonly List<Activity> _activities = new()
    {
        new Activity
        {
            Id = Guid.NewGuid(),
            Distance = 5,
            Time = "00:40:23",
            StartTime = DateTime.UtcNow
        },
        new Activity
        {
            Id = Guid.NewGuid(),
            Distance = 3,
            Time = "00:23:00",
            StartTime = DateTime.UtcNow
        },
        new Activity
        {
            Id = Guid.NewGuid(),
            Distance = 1,
            Time = "00:4:35",
            StartTime = DateTime.UtcNow
        }
    };

    public IEnumerable<Activity> GetActivities()
    {
        return _activities;
    }

    public Activity GetActivity(Guid Id)
    {
        return _activities.SingleOrDefault(a => a.Id == Id);
    }

    public void CreateActivity(Activity activity)
    {
        _activities.Add(activity);
    }

    public void UpdateActivity(Activity activity)
    {
        var index = _activities.FindIndex(existingActivity => existingActivity.Id == activity.Id);
        _activities[index] = activity;
    }

    public void DeleteActivity(Guid id)
    {
        var index = _activities.FindIndex(existingActivity => existingActivity.Id == id);
        _activities.RemoveAt(index);
    }
}