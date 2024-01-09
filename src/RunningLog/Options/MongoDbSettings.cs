namespace RunningLog.Options;

public class MongoDbSettings
{
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;

    public string ConnectionString { get; set; } = null!;
}