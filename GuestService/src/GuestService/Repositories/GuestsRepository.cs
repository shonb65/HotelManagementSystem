using System.Transactions;
using MongoDB.Driver;
using HotelManagemnt.GuestService.Entities;

namespace HotelManagemnt.GuestService.Repositories
{
    public class GuestsReposetory
    {
        private const string collectionName = "guests";
        private readonly IMongoCollection<Guest> dbCollection;
        private readonly FilterDefinitionBuilder<Guest> filterBuilder = Builders<Guest>.Filter;

        public GuestsReposetory()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Guest");
            dbCollection = database.GetCollection<Guest>(collectionName);
        }
    }
}