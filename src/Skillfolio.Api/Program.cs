
using Skillfolio.Api.setupConfigurations;

namespace Skillfolio.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.ConfigureServices();
        
        var app = builder.Build();
        app.ConfigureMiddleWare();

        app.Run();
    }
}
