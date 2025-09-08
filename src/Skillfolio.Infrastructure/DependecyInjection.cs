using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Skillfolio.Infrastructure.Database;

namespace Skillfolio.Infrastructure;

public static class DependencyInjection
{
    public static void AddDb(this IServiceCollection services, string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
    }
}