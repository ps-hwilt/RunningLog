using RunningLog.Models;

namespace RunningLog.Repositories;

public interface IActivitiesRepository
{
    IEnumerable<Activity> GetActivities();
    Activity GetActivity(int id);
}