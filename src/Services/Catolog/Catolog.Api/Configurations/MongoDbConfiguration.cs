using Catolog.Api.Configurations.Interfaces;

namespace Catolog.Api.Configurations;

public class MongoDbConfiguration : IMongoDbConfiguration
{
    public const string MongoDb = "MongoDB";

    public string ConnectionString { get; set; } = string.Empty;

    public string Database { get; set; } = string.Empty;

    public string Collection { get; set; } = string.Empty;
}