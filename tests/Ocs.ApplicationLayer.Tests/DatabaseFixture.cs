using Microsoft.EntityFrameworkCore;
using Ocs.Infrastructure;
using Testcontainers.PostgreSql;

namespace Ocs.ApplicationLayer.Tests;

public class DatabaseFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _container =
        new PostgreSqlBuilder()
            .Build();

    public string ConnectionString => _container.GetConnectionString();

    public string ContainerId => $"{_container.Id}";

    public ApplicationDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(_container.GetConnectionString())
            .Options;
        
        return new ApplicationDbContext(options);
    }


    public Task InitializeAsync() 
        => _container.StartAsync();
    public Task DisposeAsync() 
        => _container.DisposeAsync().AsTask();
}