using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TreeBoard;
using TreeMiner;

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
        

        var fileSystemMiner = new GenericTreeMiner<FileSystemArtifact, FileSystemInfo, FileInfo, DirectoryInfo>();
        var rootArtifact = fileSystemMiner.GetRootArtifact(dir);

        var artifacts = fileSystemMiner.GetArtifacts(rootArtifact, (dirInfo) => dirInfo.GetFileSystemInfos());

        foreach (var artifact in artifacts)
            Console.WriteLine($"{artifact.Id} {artifact.ParentId} [{(artifact.Info as FileSystemInfo)?.FullName}]");

        await Task.CompletedTask;
    }
}
