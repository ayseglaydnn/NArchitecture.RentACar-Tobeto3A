using Core.CrossCuttingConcers.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog;


namespace Core.CrossCuttingConcers.Logging.Serilog.Loggers;

public class MongoDbLogger : LoggerServiceBase
{
    private IConfiguration _configuration;
    public MongoDbLogger(IConfiguration configuration)
    {
        _configuration = configuration;

        var logConfig = configuration.GetSection("SeriLogConfigurations:MongoDbConfiguration")
            .Get<MongoDbConfiguration>();

        Logger = new LoggerConfiguration()
            .WriteTo.MongoDB(logConfig.ConnectionString, collectionName: logConfig.Collection)
            .CreateLogger();
    }
}