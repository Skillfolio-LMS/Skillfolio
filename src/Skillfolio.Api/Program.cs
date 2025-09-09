using dotenv.net;
using Skillfolio.Api.setupConfigurations;

namespace Skillfolio.Api;

public class Program
{
    public static void Main(string[] args)
    {
        // Load .env from repository root
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "../../.env" }));
        
        var builder = WebApplication.CreateBuilder(args);
        builder.ConfigureServices();
        
        var app = builder.Build();
        app.ConfigureMiddleWare();

        app.Run();
    }
}
