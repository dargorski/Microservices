using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _appDbContext;

    public PlatformRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public bool SaveChanges()
    {
        return _appDbContext.SaveChanges(true) >= 0;
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _appDbContext.Platforms.ToList();
    }

    public Platform GetPlatformById(int id)
    {
        return _appDbContext.Platforms.FirstOrDefault(platform => platform.Id == id);
    }

    public void CreatePlatform(Platform platform)
    {
        _appDbContext.Platforms.Add(platform);
    }
}