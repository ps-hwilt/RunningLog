namespace RunningLog.Options;

public class MongoDbSettings
{
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
    
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;

    public string Host { get; set; } = null!;
    public string Port { get; set; } = null!;

    public string ConnectionString => $"mongodb://{User}:{Password}@{Host}:{Port}";
}