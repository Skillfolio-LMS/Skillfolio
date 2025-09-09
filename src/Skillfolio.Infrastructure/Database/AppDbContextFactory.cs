using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using dotenv.net;


namespace Skillfolio.Infrastructure.Database;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {

        var builder = new DbContextOptionsBuilder<AppDbContext>();
        
        builder.UseNpgsql(Environment.GetEnvironmentVariable("dbString"));
        return new AppDbContext(builder.Options);
    }
}