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

    public async Task<IEnumerable<Activity>> GetActivitiesAsync()
    {
        return await Task.FromResult(_activities);
    }

    public async Task<Activity> GetActivityAsync(Guid Id)
    {
        return (await Task.FromResult(_activities.SingleOrDefault(a => a.Id == Id)))!;
    }

    public async Task CreateActivityAsync(Activity activity)
    {
        _activities.Add(activity);
        await Task.CompletedTask;
    }

    public async Task UpdateActivityAsync(Activity activity)
    {
        var index = _activities.FindIndex(existingActivity => existingActivity.Id == activity.Id);
        _activities[index] = activity;
        await Task.CompletedTask;
    }

    public async Task DeleteActivityAsync(Guid id)
    {
        var index = _activities.FindIndex(existingActivity => existingActivity.Id == id);
        _activities.RemoveAt(index);
        await Task.CompletedTask;
    }
}