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
    
    public async Task<IEnumerable<Activity>> GetActivitiesAsync()
    {
        return await _activitiesCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Activity> GetActivityAsync(Guid id)
    {
        var filter = _filterBuilder.Eq(activity => activity.Id, id);
        return await _activitiesCollection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task CreateActivityAsync(Activity activity)
    {
        await _activitiesCollection.InsertOneAsync(activity);
    }

    public async Task UpdateActivityAsync(Activity activity)
    {
        var filter = _filterBuilder.Eq(existingActivity => existingActivity.Id, activity.Id);
        await _activitiesCollection.ReplaceOneAsync(filter, activity);
    }

    public async Task DeleteActivityAsync(Guid id)
    {
        var filter = _filterBuilder.Eq(activity => activity.Id, id);
        await _activitiesCollection.DeleteOneAsync(filter);
    }
}