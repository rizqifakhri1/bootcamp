using System;
using Microsoft.Extensions.Logging;

class Program
{
    static void Main()
    {
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole()
            .SetMinimumLevel(LogLevel.Debug);
        });

        ILogger logger = loggerFactory.CreateLogger<Program>();
        
        logger.LogDebug("This is a Debug message");
        logger.LogInformation("This is an Information message");
        logger.LogWarning("This is a Warning message");
        logger.LogError("This is an Error message");
        logger.LogCritical("This is a Critical message");

    }
}