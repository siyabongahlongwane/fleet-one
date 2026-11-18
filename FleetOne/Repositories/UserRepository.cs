using FleetOne.Data;
using FleetOne.Dtos;
using FleetOne.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleetOne.Repositories;

public class UserRepository(ApplicationDbContext dbContext)
{
    public async Task<List<User>> GetAllAsync()
    {
        return await dbContext.Users.ToListAsync();
    }

    public async Task<User?> FindByIdAsync(Guid userId)
    {
        return await dbContext.Users.FindAsync(userId);
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await dbContext.Users.SingleOrDefaultAsync(user => user.Email == email);
    }

    public async Task<User> AddUser(User newUserEntity)
    {
        dbContext.Users.Add(newUserEntity);
        await dbContext.SaveChangesAsync();

        return newUserEntity;
    }

    public void RemoveAsync(User user)
    {
        dbContext.Users.Remove(user);
        dbContext.SaveChanges();
    }
}