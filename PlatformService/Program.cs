using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase("InMemoryDb"));
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();

var app = builder.Build();

PrepareDatabase.PreparePopulation(app);
app.MapGet("/", () => "Hello World!");

app.Run();