﻿// Created with JandaBox http://github.com/Jandini/JandaBox
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CommandLine;

await Parser.Default.ParseArguments<Options.Run>(args).WithParsedAsync(async (parameters) =>
{
    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddEmbeddedJsonFile("appsettings.json")
        .Build();

    using var provider = new ServiceCollection()
        .AddConfiguration(config)
        .AddLogging(config)
        .AddServices()
        .BuildServiceProvider();

    provider.LogVersion<Program>();

    try
    {
        var main = provider.GetRequiredService<Main>();

        switch (parameters)
        {
            case Options.Run options:
                await main.Run(options.Path);
                break;
        };
    }
    catch (Exception ex)
    {
        provider.GetService<ILogger<Program>>()?
            .LogCritical(ex, "Unhandled exception");
    }
});
