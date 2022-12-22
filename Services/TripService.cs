using grupp5.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;


namespace grupp5.Services;

public class TripService
{
    private readonly IMongoCollection<Trip> _tripCollection;

    public TripService(IOptions<TripSettings> tripSettings)
    {
        MongoClient client = new MongoClient(tripSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(tripSettings.Value.DatabaseName);
        _tripCollection = database.GetCollection<Trip>(tripSettings.Value.CollectionName);
    }

    public async Task CreateTrip(Trip trip)
    {
        await _tripCollection.InsertOneAsync(trip);
        return;
    }


    public async Task<List<Trip>> GetTrip()
    {
        return await _tripCollection.Find(new BsonDocument()).ToListAsync();
    }

/*
    public async Task AddToTripAsync(string id, string src_airport)
    {
        FilterDefinition<Trip> filter = Builders<Trip>.Filter.Eq("Id", id);
       // FieldDefinition<Trip, string> field = Builders<Trip>.
        UpdateDefinition<Trip> update = Builders<Trip>.Update.Set<string>("src_airport", src_airport);
        // .AddToSet<string>("src_airport", src_airport);
        await _tripCollection.UpdateOneAsync(filter, update);
        return;
    }
    */

    public async Task UpdateTrip(string id, Trip newTrip) => await _tripCollection.ReplaceOneAsync( trip => trip.Id == id, newTrip);

    public async Task DeleteTripAsync(string id)
    {
        FilterDefinition<Trip> filter = Builders<Trip>.Filter.Eq("Id", id);
        await _tripCollection.DeleteOneAsync(filter);
        return;
    }

}