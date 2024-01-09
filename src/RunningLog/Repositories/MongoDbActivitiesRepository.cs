using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using RunningLog.Models;
using RunningLog.Options;

namespace RunningLog.Repositories;

public class MongoDbActivitiesRepository : IActivitiesRepository
{

    
    private readonly IMongoCollection<Activity> _activitiesCollection;

    private readonly FilterDefinitionBuilder<Activity> _filterBuilder = Builders<Activity>.Filter;
    
    public MongoDbActivitiesRepository(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(
            mongoDbSettings.Value.ConnectionString);
        
        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);
        
        _activitiesCollection = mongoDatabase.GetCollection<Activity>(
            mongoDbSettings.Value.CollectionName);

    }
    
    public IEnumerable<Activity> GetActivities()
    {
        return _activitiesCollection.Find(new BsonDocument()).ToList();
    }

    public Activity GetActivity(Guid id)
    {
        var filter = _filterBuilder.Eq(activity => activity.Id, id);
        return _activitiesCollection.Find(filter).SingleOrDefault();
    }

    public void CreateActivity(Activity activity)
    {
        _activitiesCollection.InsertOne(activity);
    }

    public void UpdateActivity(Activity activity)
    {
        var filter = _filterBuilder.Eq(existingActivity => existingActivity.Id, activity.Id);
        _activitiesCollection.ReplaceOne(filter, activity);
    }

    public void DeleteActivity(Guid id)
    {
        var filter = _filterBuilder.Eq(activity => activity.Id, id);
        _activitiesCollection.DeleteOne(filter);
    }
}