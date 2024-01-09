using RunningLog.DTO;
using RunningLog.Models;

namespace RunningLog.Extensions;

public static class Extensions
{
    public static ActivityDTO AsDTO(this Activity activity)
    {
        return new ActivityDTO
        {
            Id = activity.Id,
            Time = activity.Time,
            Distance = activity.Distance,
            StartTime = activity.StartTime
        };
    }
}