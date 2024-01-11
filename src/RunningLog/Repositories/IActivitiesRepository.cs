using RunningLog.Models;

namespace RunningLog.Repositories;

public interface IActivitiesRepository
{
    Task<IEnumerable<Activity>> GetActivitiesAsync();
    Task<Activity> GetActivityAsync(Guid id);

    Task CreateActivityAsync(Activity activity);

    Task UpdateActivityAsync(Activity activity);

    Task DeleteActivityAsync(Guid id);
}