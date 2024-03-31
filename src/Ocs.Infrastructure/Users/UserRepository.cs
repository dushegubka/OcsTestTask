using Microsoft.EntityFrameworkCore;
using Ocs.Domain.Users;
using Ocs.Infrastructure.Extensions;

namespace Ocs.Infrastructure.Users;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _database;

    public UserRepository(ApplicationDbContext database)
    {
        _database = database;
    }
    

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _database.Users
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        return user?.ToDomainModel();
    }

    public async Task<User?> CreateAsync(User newUser, CancellationToken cancellationToken = default)
    {
        var userEntity = newUser.ToDatabaseEntity();
        
        await _database.Users.AddAsync(userEntity, cancellationToken);
        
        await _database.SaveChangesAsync(cancellationToken);
        
        return userEntity.ToDomainModel();
    }
}