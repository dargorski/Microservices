using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepareDatabase
{
    public static void PreparePopulation(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    private static void SeedData(AppDbContext appDbContext)
    {
        if (!appDbContext.Platforms.Any())
        {
            Console.WriteLine(" --> Seeding Data...");

            appDbContext.Platforms.AddRange(
                new Platform { Name = "dotnet", Publisher = "Microsoft", Cost = "Free" },
                new Platform { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
            );

            appDbContext.SaveChanges();
        }
        else
        {
            Console.WriteLine(" --> We already have data");
        }
    }
}