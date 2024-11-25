using AZF2S_Backend.Model;
using AZF2S_Backend.Model.ThirdParty.MongoDb;
using AZF2S_Backend.Service.ThirdParty.Interface;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AZF2S_Backend.Service.ThirdParty
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IMongoCollection<BsonDocument> _collection;
        private readonly ILogger<MongoDbService> _logger;
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public MongoDbService(MongoDbClient client, ILogger<MongoDbService> logger)
        {
            if (string.IsNullOrWhiteSpace(client.ConnectionString))
                throw new ArgumentNullException(nameof(client.ConnectionString));
            
            if (string.IsNullOrWhiteSpace(client.DataBase))
                throw new ArgumentNullException(nameof(client.DataBase));
            
            if (string.IsNullOrWhiteSpace(client.Collection))
                throw new ArgumentNullException(nameof(client.Collection));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            try
            {
                MongoClientSettings settings = MongoClientSettings.FromConnectionString(client.ConnectionString);
                settings.RetryWrites = true;
                settings.ReadConcern = ReadConcern.Majority;
                settings.WriteConcern = WriteConcern.WMajority;

                _mongoClient = new MongoClient(settings);
                _database = _mongoClient.GetDatabase(client.DataBase);
                _collection = _database.GetCollection<BsonDocument>(client.Collection);

                _logger.LogInformation($"MongoDB service initialized for database: {client.DataBase}, collection: {client.Collection}");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Failed to initialize MongoDB service");
                throw;
            }
        }

        public Task<ServiceResponse<T>> GetDocumentAsync<T>(string documentId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Dictionary<string, object>>> GetFieldsAsync(string documentId, List<string> fields)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> UpsertDocumentAsync<T>(string documentId, T data)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> UpsertFieldsAsync(string documentId, Dictionary<string, object> updates)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteDocumentAsync(string documentId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> SmoketestAsync()
        {
            throw new NotImplementedException();
        }
    }
}