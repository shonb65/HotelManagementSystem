using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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

        public async Task<IReadOnlyCollection<Guest>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Guest> GetAsync(Guid id)
        {
            FilterDefinition<Guest> filter = filterBuilder.Eq(entity => entity.Id, id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Guest entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await dbCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Guest entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<Guest> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await dbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<Guest> filter = filterBuilder.Eq(entity => entity.Id, id);
            await dbCollection.DeleteOneAsync(filter);
        }
    }
}