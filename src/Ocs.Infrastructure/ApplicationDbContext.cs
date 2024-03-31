using Microsoft.EntityFrameworkCore;
using Ocs.Infrastructure.Applications;
using Ocs.Infrastructure.Converters;
using Ocs.Infrastructure.Users;

namespace Ocs.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<ApplicationEntity> Applications { get; init; }
    
    public DbSet<UserEntity> Users { get; init; }
    

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetConverter>();
    }
}