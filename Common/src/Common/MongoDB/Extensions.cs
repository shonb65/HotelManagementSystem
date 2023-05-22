using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using HotelManagemnt.Common.Settings;
using MongoDB.Driver;

namespace HotelManagemnt.Common.MongoDB
{


    public static class Extentions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

            services.AddSingleton(serviceProvider => {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
                var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
                return mongoClient.GetDatabase(serviceSettings.ServiceName);
            });

            return services;

        }

        public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services, string collectionName)
         where T : IEntity
        {
            services.AddSingleton<IReposetory<T>>(ServiceProvider => {
                var database = ServiceProvider.GetService<IMongoDatabase>();
                return new MongoReposetory<T>(database, collectionName);
            });
            return services;

        }
    }
}