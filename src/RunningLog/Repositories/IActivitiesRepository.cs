using RunningLog.Models;

namespace RunningLog.Repositories;

public interface IActivitiesRepository
{
    IEnumerable<Activity> GetActivities();
    Activity GetActivity(Guid id);

    void CreateActivity(Activity activity);

    void UpdateActivity(Activity activity);

    void DeleteActivity(Guid id);
}