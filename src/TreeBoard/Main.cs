using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

internal class Main
{
    private readonly ILogger<Main> _logger;
    private readonly IConfiguration _config;

    public Main(ILogger<Main> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }
    public async Task Run(string path)
    {
        var dir = new DirectoryInfo(path);
        _logger.LogInformation(_config.Bind<Settings>("TreeBoard").Message, dir.Name, dir.GetFiles().Length);
        await Task.CompletedTask;
    }
}
